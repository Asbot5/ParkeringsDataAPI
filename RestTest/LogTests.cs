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
        public void LogTestAddOmr�deNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Nedb�r = 0;
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
            log.Omr�deId = GetOmr�deID();
            log.Nedb�r = 0;
            log.Retning = false;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }

        // There is no way to test if it hasn't been defined.
        /*
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddRetningNotNull()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = GetOmr�deID();
            log.Nedb�r = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        */

        [TestMethod]
        public void LogTestAddPositive()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = GetOmr�deID();
            log.Nedb�r = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            int i = LogManager.GetAll().Count();
            LogManager.Add(log);
            int j = LogManager.GetAll().Count();
            Assert.AreEqual(i + 1, j);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddNedb�rNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = GetOmr�deID();
            log.Retning = false;
            log.Nedb�r = -10;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddVindhastighedNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = GetOmr�deID();
            log.Retning = false;
            log.Nedb�r = 0;
            log.Temperatur = 0;
            log.Vindhastighed = -10;
            LogManager.Add(log);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestAddOmr�deIdNotNegative()
        {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = -10;
            log.Retning = false;
            log.Nedb�r = 0;
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
        public void LogTestGetPositive() {
            Log log = new Log();
            log.Tidspunkt = DateTime.Now;
            log.Omr�deId = GetOmr�deID();
            log.Nedb�r = 0;
            log.Temperatur = 0;
            log.Vindhastighed = 0;
            log.Retning = false;
            int i = LogManager.GetAll().Count();
            LogManager.Add(log);
            Assert.AreEqual(LogManager.GetAll().Count, i + 1);
        }

        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetOmr�deNotNull()
        {
            LogManager.Get(default(int), DateTime.Now);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentNullException)))]
        public void LogTestGetDateTimeNotNull() {
            LogManager.Get(GetOmr�deID(), default(DateTime));
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetOmr�deNotNegative() {
            LogManager.Get(-1, DateTime.Now);
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetDateTimeInRange() {
            LogManager.Get(GetOmr�deID(), DateTime.MinValue.AddYears(1));
        }
        [TestMethod]
        [ExpectedException((typeof(ArgumentException)))]
        public void LogTestGetOmr�deExists() {
            LogManager.Get(int.MaxValue, DateTime.Now);
        }
        #endregion
        #region GetStatistic
        [TestMethod]
        public void LogTestGetStatistic()
        {
            Assert.IsNotNull(LogManager.GetStatistic(DateTime.Now.Date, 1));
        }
        #endregion


        public static int GetOmr�deID() {
            return Parkeringsomr�deManager.GetActiveIds()[0];
        }
    }
}
