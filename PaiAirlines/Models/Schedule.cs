using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Schedule
    {
        #region Properties
        public int ID { get; set; }

        public Flight Flt { get; set; }

        public DateTime Boarding { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; } 
        #endregion
    }
}
