using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class User
    {
        #region Properties
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Country Cntry { get; set; }

        public City Cty { get; set; }

        public string Street { get; set; }

        public string Phone { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsMatmid { get; set; } 
        #endregion

    }
}
