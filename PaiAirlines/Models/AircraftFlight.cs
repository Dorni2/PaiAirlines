using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class AircraftFlight
    {
        #region Propties
        public int ID { get; set; }

        // Id of the flight time in the scheduler
        public Schedule schdl { get; set; }

        // Id of aircraft in this flight
        public Aircraft arcft { get; set; }

        // Id of flight, which flight will occure in this time with this airplane
        public Flight flght { get; set; }

        // Amount of taken economy seats
        public int EconomySeatsTaken { get; set; }

        // Amount of taken bussiness seats
        public int BussinessSeatsTaken { get; set; }

        // Amount of taken first seats
        public int FirstSeatsTaken { get; set; } 
        #endregion
    }
}
