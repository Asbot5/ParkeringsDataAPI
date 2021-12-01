using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using ParkeringsDataAPI.Models;

namespace ParkeringsDataAPI.Controllers
{
    // /ParkingDatum
    [Route("[controller]")]
    [ApiController]
    public class ParkingDatumsController : ControllerBase
    {
        private ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        [HttpGet]
        public List<Parkeringsområde> GetAll()
        {
            return _db.Parkeringsområdes.ToList();
        }

        [Route("Special")]
        [HttpGet]
        public List<SpecielleParkeringsPladser> GetAllSpecial()
        {
            return _db.SpecielleParkeringsPladsers.ToList();
        }

        [Route("Special/{område}")]
        [HttpGet]
        public List<SpecielleParkeringsPladser> GetSpecialById(int område)
        {
            List<SpecielleParkeringsPladser> liste = new List<SpecielleParkeringsPladser>();
            using (SqlConnection conn = new SqlConnection(
                    "Data Source=emilzealanddb.database.windows.net;Initial Catalog=ParkeringsDataDb;User ID=emiladmin;Password=Sql12345;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    conn.Open();
                    using (SqlCommand sql = new SqlCommand(
                        "select * from SpecielleParkeringsPladser Where (OmrådeId = @OID)",
                        conn))
                    {
                        sql.Parameters.AddWithValue("@OID", område);
                        SqlDataReader reader = sql.ExecuteReader();
                        if (reader.Read())
                        {
                            SpecielleParkeringsPladser special = new SpecielleParkeringsPladser();
                            special.OmrådeId = område;
                            special.ParkeringsType = reader.GetInt32(1);
                            special.Pladser = reader.GetInt32(2);
                            special.OptagedePladser = reader.GetInt32(3);
                            liste.Add(special);
                        }
                    }
                }
            return liste;
        }
    }
}
