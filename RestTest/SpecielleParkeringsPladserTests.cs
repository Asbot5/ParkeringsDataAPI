using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkeringsDataAPI.Models;
using ParkeringsDataAPI.Managers;
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
            //spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }

        // Når int ikke er defineret er den 0, så det er desværre ikke muligt at lave disse check.
        /*
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddParkeringsTypeNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            //spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddOptagedePladserNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            //spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        */

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestAddPladserNotNull() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            //spp.Pladser = 10;
            spp.OptagedePladser = 5;
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
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = -1;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddParkeringsTypeInRange() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 3;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddPladserNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = -10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddOptagedePladserNotNegative() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = -5;
            SpecielleParkeringsPladserManager.Add(spp);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestAddPladserBiggerThanOptagedePladser() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 5;
            spp.OptagedePladser = 10;
            SpecielleParkeringsPladserManager.Add(spp);
        }
        #endregion

        // This is hard to make work do to it requiring the absense of a similar table.
        // Best fix would be to make a remove method in SpecielleParkeringsPladserManager,
        // but even that is rather involved.
        /*
        [TestMethod]
        public void SpecielleParkeringsPladserTestAddPositive() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            int i = SpecielleParkeringsPladserManager.GetAll().Count();
            SpecielleParkeringsPladserManager.Add(spp);
            int j = SpecielleParkeringsPladserManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }
        */
        #endregion
        #region GetAll
        [TestMethod]
        public void SpecielleParkeringsPladserTestGetAllPositive() {
            Assert.IsNotNull(SpecielleParkeringsPladserManager.GetAll());
        }
        #endregion
        #region Get

        // This is hard to make work do to it requiring the absense of a similar table.
        // Best fix would be to make a remove method in SpecielleParkeringsPladserManager,
        // but even that is rather involved.
        /*
        [TestMethod]
        public void SpecielleParkeringsPladserTestGetPositive() {
            SpecielleParkeringsPladser spp = new SpecielleParkeringsPladser();
            spp.OmrådeId = LogTests.GetOmrådeID();
            spp.ParkeringsType = 0;
            spp.Pladser = 10;
            spp.OptagedePladser = 5;
            SpecielleParkeringsPladserManager.Add(spp);
            SpecielleParkeringsPladser getspp = SpecielleParkeringsPladserManager.Get(spp.OmrådeId, spp.ParkeringsType);
            Assert.IsTrue(spp.Pladser == getspp.Pladser && spp.OptagedePladser == getspp.OptagedePladser);
        }
        */

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeNotNull() {
            SpecielleParkeringsPladserManager.Get(default(int), 0);
        }

        // Since default of int is 0, this is unfortunately untestable, unless we change
        // the valid range to be [1-3] instead of [0-2].
        /*
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeNotNull() {
            SpecielleParkeringsPladserManager.Get(0, null);
        }
        */

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeNotNegative() {
            SpecielleParkeringsPladserManager.Get(-1, 0);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeNotNegative() {
            SpecielleParkeringsPladserManager.Get(LogTests.GetOmrådeID(), -1);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetParkingTypeInRange() {
            SpecielleParkeringsPladserManager.Get(LogTests.GetOmrådeID(), 3);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void SpecielleParkeringsPladserTestGetOmrådeExists() {
            SpecielleParkeringsPladserManager.Get(int.MaxValue, 0);
        }
        #endregion
    }
}
