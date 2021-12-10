using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkeringsDataAPI.Models;
using ParkeringsDataAPI.Managers;

namespace ParkeringsDataAPI.Controllers
{
    // /log
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        /// <summary>
        /// Gets all logs
        /// </summary>
        /// <returns>A list of logs</returns>
        [HttpGet]
        public List<Log> GetAll()
        {
            return LogManager.GetAll();
        }

        //Dato bliver givet i form af Amerikansk Standard af en eller anden grund så husk at skrive dato ind som MM-dd-yyyy
        /// <summary>
        /// Gets all logfiles for the date in the time 00:00 - 23:59 in specific area
        /// </summary>
        /// <param name="dato">The date of which you want the logfile</param>
        /// <param name="område">The area you want the logfile from</param>
        /// <returns>A list of logfiles</returns>
        [Route("statistic/{område}/{date}")]
        [HttpGet]
        public List<Log> GetAll(DateTime date, int område)
        {
            return LogManager.GetStatistic(date, område);
        }
    }
}
