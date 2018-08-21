using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Aircraft
    {
        #region Properties
        public int ID { get; set; }

        // Aircraft type. e.g. "Boeing 787-9"
        public string Type { get; set; }

        // Aircraft length in meters
        public int Size { get; set; }

        // Amount of economy seats
        public int EconomySeats { get; set; }

        // Amount of bussiness seats
        public int BussinessSeats { get; set; }

        // Amount of first seats
        public int FirstSeats { get; set; }

        // Aircraft range in meters
        public int Range { get; set; } 
        #endregion
    }
}
