using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Ticket
    {
        #region Properties
        public int ID { get; set; }

        public Booking bkn { get; set; }

        public Seat seat { get; set; }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } 
        #endregion
    }
}
