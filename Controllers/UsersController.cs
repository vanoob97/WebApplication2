using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication2.Attributes;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/anomalies")]
    [ApiController]
    //comment apikey attribute for xunit tests to work
    [ApiKey]
    public class UsersController : ControllerBase
    {
        testdbContext db;
        public class UnexpectedLogin { 
            public string Country { get; set; }
            public DateTime LoginTime { get; set; }
        }
        public class Users
        {
            public string UserName { get; set; }
            public string Device { get; set; }
            public DateTime LoginTime { get; set; }
            public UnexpectedLogin UnexpLogin { get; set; }
        }

        List<Users> userlist;

        public UsersController(testdbContext context)
        {
            db = context;
            userlist = new List<Users>();
            var users = db.LoginUserCountries.ToList();
            var concsessions = db.ConcsessionsMultDevices.ToList();
            foreach (LoginUserCountry luc in users)
            {
                Users u = new Users();
                u.UserName = luc.UserName;
                u.LoginTime = luc.LoginTs;
                u.Device = concsessions.FirstOrDefault(x => x.LoginTs == luc.LoginTs).DeviceName;
                u.UnexpLogin = new UnexpectedLogin() { Country = luc.Country, LoginTime = luc.LoginTs };
                userlist.Add(u);
            }
        }

        [HttpGet]
        public string Get()
        {
            return userlist.Count == 0 ? JsonConvert.SerializeObject("[]") : JsonConvert.SerializeObject(userlist);
        }
    }
}
