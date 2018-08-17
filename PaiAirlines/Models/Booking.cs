using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Booking
    {
        #region Properties

        public int ID { get; set; }


        public User Usr { get; set; }

        public Schedule Scdl { get; set; }

        public Aircraft Arcft { get; set; }

        public Flight Flt { get; set; }

        public int TotalPrice { get; set; } 

        #endregion
    }
}
