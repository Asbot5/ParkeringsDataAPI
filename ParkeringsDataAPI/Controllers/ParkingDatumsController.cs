using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        [Route("Special/{id}")]
        [HttpGet]
        public IQueryable GetAllSpecialById(int id)
        {
        //    var s = from sp in _db.SpecielleParkeringsPladsers
        //        where sp.OmrådeId == id
        //        select new {sp.OmrådeId, sp.OptagedePladser, sp.ParkeringsType, sp.Pladser};
        //    return s;
            var s =_db.SpecielleParkeringsPladsers
                .Where(sp => sp.OmrådeId == id)
                .Select(sp => new {
                    id = sp.OmrådeId,
                    områdeId = sp.OmrådeId,
                    pladser = sp.Pladser,
                    optagedePladser = sp.OptagedePladser,
                    parkeringsType = sp.ParkeringsType
                });
                return s;
        }
    }
}
