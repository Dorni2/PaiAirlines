using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Price
    {
        #region Properties
        public int ID { get; set; }

        public int FlightId { get; set; }

        public int ScheduleId { get; set; }

        // Price of Economy seat
        public int Economy { get; set; }

        // Price of Bussiness seat
        public int Bussiness { get; set; }

        // Price of First seat
        public int First { get; set; }

        // Price of Luggage
        public int LuggagePrice { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; } 
        #endregion

    }
}
