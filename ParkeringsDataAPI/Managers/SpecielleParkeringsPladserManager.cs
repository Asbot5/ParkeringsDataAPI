using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkeringsDataAPI.Managers {
    public static class SpecielleParkeringsPladserManager {

        private static ParkeringsdatadbContext _db = new ParkeringsdatadbContext();

        public static void Add(SpecielleParkeringsPladser spp) {
            if (spp.Pladser == default(int)) {
                throw new ArgumentNullException("Pladser can not be undefined");
            } else if (spp.OmrådeId == default(int)) {
                throw new ArgumentNullException("OmrådeId can not be undefined");
            } else if (spp.OmrådeId < 0) {
                throw new ArgumentException("OmrådeId can not be negative");
            } else if (spp.Pladser < 0) {
                throw new ArgumentException("Pladser can not be negative");
            } else if (spp.ParkeringsType < 0 || spp.ParkeringsType > 2) {
                throw new ArgumentException("ParkeringsType must be [0-2]");
            } else if (spp.OptagedePladser < 0) {
                throw new ArgumentException("OptagedePladser can not be negative");
            } else if (spp.OptagedePladser > spp.Pladser) {
                throw new ArgumentException("OptagedePladser must be less than Pladser");
            }

            _db.Add(spp);
            _db.SaveChanges();
        }

        public static List<SpecielleParkeringsPladser> GetAll() {
            return _db.SpecielleParkeringsPladsers.ToList();
        }

        public static SpecielleParkeringsPladser Get(int områdeId, int parkeringsType) {

            if (områdeId == default(int)) {
                throw new ArgumentNullException("OmrådeId can't be undefined");
            } else if (områdeId < 0) {
                throw new ArgumentException("OmrådeId can't be negative.");
            } else if (!ParkeringsområdeManager.GetActiveIds().Contains(områdeId)) {
                throw new ArgumentException("OmrådeId must be equal to the id of a \"Parkeringsområde\" object.");
            } else if (parkeringsType < 0 || parkeringsType > 2) {
                throw new ArgumentException("ParkeringsType must be [0-2]");
            }

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
