using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkeringsDataAPI.Models;

namespace ParkeringsDataAPI.Controllers
{
    // /log
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ParkeringsdatadbContext _db = new ParkeringsdatadbContext();
        [HttpGet]
        public List<Log> GetAll()
        {
            return _db.Logs.ToList();
        }
    }
}
