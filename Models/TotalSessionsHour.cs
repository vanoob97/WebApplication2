using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class TotalSessionsHour
    {
        public DateTime DateTs { get; set; }
        public int HourTs { get; set; }
        public int TotalSDurationMinutes { get; set; }
        public int TotalSDurationAcc { get; set; }
    }
}
