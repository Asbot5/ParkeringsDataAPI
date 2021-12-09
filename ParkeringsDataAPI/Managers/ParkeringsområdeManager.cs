using Microsoft.EntityFrameworkCore.ChangeTracking;
using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkeringsDataAPI.Managers {
    public static class ParkeringsområdeManager {

        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        public static int Add(Parkeringsområde po) {
            if (po.Pladser == default(int)) {
                throw new ArgumentNullException("Pladser can not be undefined");
            } else if (po.Pladser < 0) {
                throw new ArgumentException("Pladser can not be negative");
            } else if (po.OptagedePladser < 0) {
                throw new ArgumentException("OptagedePladser can not be negative");
            } else if (po.OptagedePladser > po.Pladser) {
                throw new ArgumentException("OptagedePladser must be less than Pladser");
            }

            EntityEntry<Parkeringsområde> newPo = _db.Parkeringsområdes.Add(po);
            _db.SaveChanges();
            return newPo.Entity.Id;
        }

        public static List<Parkeringsområde> GetAll() {
            return _db.Parkeringsområdes.ToList();
        }

        public static Parkeringsområde Get(int id) {
            if (id == default(int)) {
                throw new ArgumentNullException("Id can't be undefined");
            } else if (id < 0) {
                throw new ArgumentException("Id can't be negative.");
            }

            List<Parkeringsområde> list = _db.Parkeringsområdes.ToList();
            foreach (Parkeringsområde po in list) {
                if (po.Id == id) {
                    return po;
                }
            }
            return null;
        }

        public static List<int> GetActiveIds() {
            List<Parkeringsområde> pos = _db.Parkeringsområdes.ToList();

            List<int> ints = new List<int>();
            foreach(Parkeringsområde po in pos) {
                ints.Add(po.Id);
            }
            return ints;
        }
    }
}
