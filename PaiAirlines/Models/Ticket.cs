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

        public int FlightID { get; set; }

        public User UserID { get; set; }
        #endregion
    }
}
