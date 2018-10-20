using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class Seat
    {
        #region Properties
        public int ID { get; set; }

        public Aircraft Arcft { get; set; }

        public int SeatNum { get; set; }

        public int ClassId { get; set; } 
        #endregion
    }
}
