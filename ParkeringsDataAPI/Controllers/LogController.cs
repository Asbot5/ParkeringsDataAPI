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
        
        [HttpGet]
        public List<Log> GetAll()
        {
            return LogManager.GetAll();
        }

        //Dato bliver givet i form af Amerikansk Standard af en eller anden grund så husk at skrive dato ind som MM-dd-yyyy
        [Route("statistic/{område}/{date}")]
        [HttpGet]
        public List<Log> GetAll(DateTime date, int område)
        {
            return LogManager.GetStatistic(date, område);
        }
    }
}
