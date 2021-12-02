using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkeringsDataAPI.Models;

namespace ParkeringsDataAPI.Managers
{
    public static class LogManager
    {
        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

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
    }
}
