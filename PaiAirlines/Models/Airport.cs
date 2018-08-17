using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaiAirlines.Models
{
    public class Airport
    {
        #region Properties
        public int ID { get; set; }

        // Airport Name e.g. Natbag
        public string Name { get; set; }

        // Airport location 
        public int Coordinates { get; set; }

        // e.g TLV/LAX
        public string IATAcode { get; set; }

        // Airport's city
        public City cty { get; set; } 
        #endregion
    }
}
