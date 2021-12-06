using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest {
    [TestClass]
    public class SpecielleParkeringsPladserTests {
        #region Add
        #region NotNull
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddOmrådeIdNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            //spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddParkeringsTypeNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            //spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddPladserNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            //spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddOptagedePladserNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            //spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        #endregion
        #region NotNegative / Inrange / Logic
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddOmrådeIdNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = -1;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddParkeringsTypeNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = -1;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddParkeringsTypeInRange() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 3;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddPladserNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = -10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddOptagedePladserNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = -5;
            SpecielleParkeringsPladserManager.Add(spp);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddPladserBiggerThanOptagedePladser() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 5;
            spp.OptagedePladser = 10;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        #endregion

        [TestMethod]
        public void SpecielleParkeringsPladserTestAddPositive() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            int i = SpecielleParkeringsPladserManager.GetAll().Count();
            SpecielleParkeringsPladserManager.Add(spp);
            int j = SpecielleParkeringsPladserManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }
        #endregion
        #region GetAll
        [TestMethod]
        public void SpecielleParkeringsPladserTestGetAllPositive() {
            Assert.IsNotNull(SpecielleParkeringsPladserManager.GetAll());
        }
        #endregion
        #region Get
        [TestMethod]
        public void SpecielleParkeringsPladserTestGetPositive() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = 0;
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
            SpecielleParkeringsPladser getspp = SpecielleParkeringsPladserManager.Get(spp.OmrådeId, spp.ParkeringsType);
            Assert.AreEqual(spp, getspp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeNotNull() {
            SpecielleParkeringsPladserManager.Get(null, 0);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeNotNull() {
            SpecielleParkeringsPladserManager.Get(0, null);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeNotNegative() {
            SpecielleParkeringsPladserManager.Get(-1, 0);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeNotNegative() {
            SpecielleParkeringsPladserManager.Get(0, -1);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeInRange() {
            SpecielleParkeringsPladserManager.Get(0, 3);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeExists() {
            SpecielleParkeringsPladserManager.Get(int.MaxValue, 0);
        }
        #endregion
    }
}
