using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkeringsDataAPI.Managers {
    public static class ParkeringsområdeManager
    {
        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        private static string ConnectionString =
            "Data Source=emilzealanddb.database.windows.net;Initial Catalog=ParkeringsDataDb;User ID=emiladmin;Password=Sql12345;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Add(Parkeringsområde po)
        {
            if (po.OptagedePladser == 0)
            {
                throw new ArgumentNullException("Optagede pladser cant be null");
            }

            if (po.Pladser == 0)
            {
                throw new ArgumentNullException();
            }

            if (po.Pladser < 0)
            {
                throw new ArgumentException("Pladser can't be negative");
            }
            if (po.OptagedePladser < 0)
            {
                throw new ArgumentException("OptagedePladser can't be negative");
            }

            if (po.OptagedePladser > po.Pladser)
            {
                throw new ArgumentException("OptagedePladser can't be larger than Pladser");
            }

            _db.Add(po);
            _db.SaveChanges();
        }

        public static List<Parkeringsområde> GetAll()
        {
            return _db.Parkeringsområdes.ToList();
        }

        public static Parkeringsområde Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id can't be null");
            }

            if (id < 0)
            {
                throw new ArgumentException("Id can't be negative");
            }
            return _db.Parkeringsområdes.Find(id);
        }

        public static List<int> GetActiveIds() {
            List<int> ints = new List<int>();
            foreach(Parkeringsområde po in _db.Parkeringsområdes) {
                ints.Add(po.Id);
            }
            return ints;
        }
    }
}