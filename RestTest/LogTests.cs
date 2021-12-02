using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkeringsDataAPI.Managers;
using ParkeringsDataAPI.Models;

namespace RestTest
{
    [TestClass]
    public class LogTests
    {
        #region Add
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddOmrådeNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Nedbør = 0;
            log.Retning = false;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddDateTimeNotNull()
        {
            Log log = new Log();
            log.OmrådeId = 0;
            log.Nedbør = 0;
            log.Retning = false;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddRetningNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = 0;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        public void LogTestAddPositive()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = 0;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            int i = LogManager.GetAll().Count();
            LogManager.Add(log);
            int j = LogManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddNedbørNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = 0;
            log.Retning = false;
            log.Nedbør = -10;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddVindhastighedNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = 0;
            log.Retning = false;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = -10;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestAddOmrådeIdNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = -10;
            log.Retning = false;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        #endregion
        #region GetAll
        [TestMethod]
        public void LogTestGetAllPositive()
        {
            Assert.IsNotNull(LogManager.GetAll());
        }
        #endregion
        #region Get
        [TestMethod]
        public void LogTestGetPositive()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.OmrådeId = 0;
            log.Nedbør = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            LogManager.Add(log);
            Log getlog = LogManager.Get(log.OmrådeId, log.Tidspunkt);
            Assert.AreEqual(log, getlog);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetOmrådeNotNull()
        {
            LogManager.Get(null, DateTime.Now);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetDateTimeNotNull()
        {
            LogManager.Get(0, null);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetDateTimeInRange()
        {
            LogManager.Get(0, DateTime.MinValue);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetOmrådeExists()
        {
            LogManager.Get(int.MaxValue, DateTime.Now);
        }
#endregion
    }
}
