using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkeringsDataAPI.Managers {
    public static class SpecielleParkeringsPladserManager {

        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        public static void Add(SpecielleParkeringsPladser spp) {
            _db.Add(spp);
        }

        public static List<SpecielleParkeringsPladser> GetAll() {
            return _db.SpecielleParkeringsPladsers.ToList();
        }

        public static SpecielleParkeringsPladser Get(int? områdeId, int? parkeringsType) {
            List<SpecielleParkeringsPladser> list = _db.SpecielleParkeringsPladsers.ToList();
            foreach (SpecielleParkeringsPladser spp in list) {
                if (spp.OmrådeId == områdeId && spp.ParkeringsType == parkeringsType) {
                    return spp;
                }
            }
            return null;
        }
    }
}
