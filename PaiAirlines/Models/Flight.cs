using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Flight
    {
        #region Properties

        // Flight ID, primary key.
        public int ID { get; set; }

        // Flight number. e.g. (pai)058
        public int FlightNumber { get; set; }

        // Id of origin. e.g. for TLV, id=4
        public int OriginId { get; set; }

        // Id of destination. e.g. for TLV, id=4
        public int DestinationId { get; set; }

        #endregion
    }
}
