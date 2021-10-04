using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication2.Attributes;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/bymonth")]
    [ApiController]
    //comment apikey attribute for xunit tests to work
    [ApiKey]
    public class RegistrationController : ControllerBase
    {
        testdbContext db;
        public class DevDto
        {
            public string Type;
            public int Amount;
        }
        public class RegDto
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int RegisteredUsers { get; set; }
            public ICollection<DevDto> RegisteredDevices { get; set; }
        }

        List<RegDto> regs;

        public RegistrationController(testdbContext context)
        {
            db = context;
            regs = db.RegdynamicsUsers.
                Select(r => new RegDto
                {
                    Year = r.RegYear,
                    Month = r.RegMonth,
                    RegisteredUsers = r.NumberOfUsers,
                    RegisteredDevices = db.RegdynamicsDevices.Where(x => x.RegYear == r.RegYear && x.RegMonth == r.RegMonth).Select(d => new DevDto
                    {
                        Type = d.DeviceType,
                        Amount = d.NumberOfUsers
                    }).ToList()
                }).ToList();
        }

        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(regs.First(x => DateTime.Now.Year == x.Year && DateTime.Now.Month == x.Month));
        }

        [HttpGet("{ym}")]
        public string Get(string ym)
        {
            int year = Convert.ToInt32(ym.Substring(0, 4));
            int month = Convert.ToInt32(ym.Substring(4));
            var reg = regs.FirstOrDefault(x => x.Year == year && x.Month == month);
            if (reg == null)
            {
                Response.StatusCode = 404;
                return "404 not found";
            }
            return JsonConvert.SerializeObject(reg);
        }
    }
}
