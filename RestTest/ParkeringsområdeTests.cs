using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkeringsDataAPI.Managers;
using ParkeringsDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest {
    [TestClass]
    public class ParkeringsområdeTests {
        #region Add
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void ParkeringsområdeTestAddPladserNotNull() {
            Parkeringsområde po = new Parkeringsområde();
            po.OptagedePladser = 5;
            ParkeringsområdeManager.Add(po);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void ParkeringsområdeTestAddOptagedePladserNotNull() {
            Parkeringsområde po = new Parkeringsområde();
            po.Pladser = 10;
            //po.OptagedePladser = 5;
            ParkeringsområdeManager.Add(po);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void ParkeringsområdeTestAddPladserNotNegative() {
            Parkeringsområde po = new Parkeringsområde();
            po.Pladser = -10;
            po.OptagedePladser = 5;
            ParkeringsområdeManager.Add(po);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void ParkeringsområdeTestAddOptagedePladserNotNegative() {
            Parkeringsområde po = new Parkeringsområde();
            po.Pladser = 10;
            po.OptagedePladser = -5;
            ParkeringsområdeManager.Add(po);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void ParkeringsområdeTestAddPladserBiggerThanOptagedePladser() {
            Parkeringsområde po = new Parkeringsområde();
            po.Pladser = 5;
            po.OptagedePladser = 10;
            ParkeringsområdeManager.Add(po);
        }

        [TestMethod]
        public void ParkeringsområdeTestAddPositive() {
            Parkeringsområde po = new Parkeringsområde();
            po.Pladser = 10;
            po.OptagedePladser = 5;
            int i = ParkeringsområdeManager.GetAll().Count();
            ParkeringsområdeManager.Add(po);
            int j = ParkeringsområdeManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }
        #endregion
        #region GetAll
        [TestMethod]
        public void ParkeringsområdeTestGetAllPositive() {
            Assert.IsNotNull(ParkeringsområdeManager.GetAll());
        }
        #endregion
        #region Get
        [TestMethod]
        public void ParkeringsområdeTestGetPositive()
        {
            Parkeringsområde po = new();
            po.Pladser = 10;
            po.OptagedePladser = 5;
            ParkeringsOmrådeManager.Add(po);
            Parkeringsområde getpo = ParkeringsOmrådeManager.Get(po.Id);
            Assert.IsTrue(po.Pladser == getpo.Pladser && po.OptagedePladser == getpo.OptagedePladser);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void ParkeringsområdeTestGetIdNotNull()
        {
            ParkeringsOmrådeManager.Get(null);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void ParkeringsområdeTestGetIdNotNegative()
        {
            ParkeringsOmrådeManager.Get(-1);
        }
        #endregion
    }
}
