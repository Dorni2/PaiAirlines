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

        public int Userid { get; set; }

        public int FlightID { get; set; }

        public int SeatsAmount { get; set; }

        public int TotalPrice { get; set; } 

        #endregion
    }
}
