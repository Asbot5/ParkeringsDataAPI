using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ParkeringsDataAPI.Models;

namespace ParkeringsDataAPI.Managers
{
    public static class LogManager
    {
        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        private static string ConnectionString =
            "Data Source=emilzealanddb.database.windows.net;Initial Catalog=ParkeringsDataDb;User ID=emiladmin;Password=Sql12345;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Log> GetAll()
        {
            return _db.Logs.ToList();
        }

        public static void Add(Log log)
        {
            if (log.Tidspunkt == null)
            {
                throw new ArgumentException("Time can not be null");
            }

            if (log.OmrådeId == null || log.OmrådeId < 0)
            {
                throw new ArgumentException("OmrådeId can not be null or negative");
            }

            if (log.Retning == null)
            {
                throw new ArgumentException("Retning must be defined");
            }

            if (log.Nedbør < 0)
            {
                throw new ArgumentException("The sky does not vacuum");
            }

            if (log.Vindhastighed < 0)
            {
                throw new ArgumentException("Windspeed can not be below 0");
            }
            _db.Add(log);
        }
        //Dato bliver givet i form af Amerikansk Standard af en eller anden grund så husk at skrive dato ind som MM-dd-yyyy
        public static List<Log> GetStatistic(DateTime dato, int område)
        {
            List<Log> liste = new List<Log>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand sql = new SqlCommand(
                    "select * from Log Where (OmrådeId = @OID) AND (Tidspunkt BETWEEN @Date AND @Midnight)", conn))
                {
                    sql.Parameters.AddWithValue("@OID", område);
                    sql.Parameters.AddWithValue("@Date",  dato.Date);
                    sql.Parameters.AddWithValue("@Midnight", dato.AddHours(23).AddMinutes(59).AddSeconds(59));
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        Log log = new Log();
                        log.OmrådeId = reader.GetInt32(0);
                        log.Tidspunkt = reader.GetDateTime(1);
                        log.Retning = reader.GetBoolean(2);
                        log.Nedbør = reader.GetInt32(3);
                        log.Temperatur = reader.GetInt32(4);
                        log.Vindhastighed = reader.GetInt32(5);

                        liste.Add(log); ;
                    }
                    return liste;
                }
            }



            //var statistic = _db.Logs.Where(i => i.Tidspunkt == dato.Date).ToList();
            //return statistic;
        }
    }
}
