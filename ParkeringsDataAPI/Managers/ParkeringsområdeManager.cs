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
            EntityEntry<Parkeringsområde> newPo = _db.Parkeringsområdes.Add(po);
            return newPo.Entity.Id;
        }

        public static List<Parkeringsområde> GetAll() {
            return _db.Parkeringsområdes.ToList();
        }

        public static Parkeringsområde Get(int? id) {
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
