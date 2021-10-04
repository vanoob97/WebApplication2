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
    [Route("api/sessions/byhour")]
    [ApiController]
    //comment apikey attribute for xunit tests to work
    [ApiKey]
    public class SessionsController : ControllerBase
    {
        testdbContext db;
        public class Sessions {
            public string Date { get; set; }
            public int Hour { get; set; }
            public int ConcurrentSessions { get; set; }
            public int TotalTimeForHour { get; set; }
            public int QumulativeForHour { get; set; }
        }

        List<Sessions> seslist;

        public SessionsController(testdbContext context)
        {
            db = context;
            seslist = new List<Sessions>();
            var concsessions = db.ConcsessionsHours.ToList();
            var sessionshours = db.TotalSessionsHours.ToList();
            foreach (ConcsessionsHour c in concsessions) {
                Sessions s = new Sessions();
                s.Date = c.HourTs.Date.ToString().Split(' ')[0];
                s.Hour = c.HourTs.Hour;
                s.ConcurrentSessions = c.MaxConcsessions;
                foreach (TotalSessionsHour t in sessionshours) {
                    if (t.DateTs.Date == c.HourTs.Date && t.HourTs == c.HourTs.Hour) {
                        s.TotalTimeForHour = t.TotalSDurationAcc;
                        s.QumulativeForHour = t.TotalSDurationMinutes;
                        break;
                    }
                }
                seslist.Add(s);
            }
        }

        [HttpGet]
        public string Get(DateTime startTime, DateTime endTime)
        {
            List<Sessions> res = new List<Sessions>();
            if (startTime == DateTime.MinValue && endTime == DateTime.MinValue) return JsonConvert.SerializeObject(seslist);
            else if (startTime == DateTime.MinValue && endTime != DateTime.MinValue) {
                foreach (Sessions s in seslist)
                {
                    string[] sesdate = s.Date.Split('.');
                    int year = Convert.ToInt32(sesdate[2]);
                    int month = Convert.ToInt32(sesdate[1]);
                    int day = Convert.ToInt32(sesdate[0]);
                    int hour = s.Hour;
                    if (DateTime.Compare(new DateTime(year, month, day, hour, 0, 0), endTime) <= 0) res.Add(s);
                }
            }
            else if (startTime != DateTime.MinValue && endTime == DateTime.MinValue) {
                foreach (Sessions s in seslist)
                {
                    string[] sesdate = s.Date.Split('.');
                    int year = Convert.ToInt32(sesdate[2]);
                    int month = Convert.ToInt32(sesdate[1]);
                    int day = Convert.ToInt32(sesdate[0]);
                    int hour = s.Hour;
                    if (DateTime.Compare(new DateTime(year, month, day, hour, 0, 0), startTime) >= 0) res.Add(s);
                }
            }
            else {
                foreach (Sessions s in seslist)
                {
                    string[] sesdate = s.Date.Split('.');
                    int year = Convert.ToInt32(sesdate[2]);
                    int month = Convert.ToInt32(sesdate[1]);
                    int day = Convert.ToInt32(sesdate[0]);
                    int hour = s.Hour;
                    if (DateTime.Compare(new DateTime(year, month, day, hour, 0, 0), startTime) >= 0 &&
                        DateTime.Compare(new DateTime(year, month, day, hour, 0, 0), endTime) <= 0) res.Add(s);
                }
            }
            return res.Count == 0 ? JsonConvert.SerializeObject("[]") : JsonConvert.SerializeObject(res);
        }
    }
}
