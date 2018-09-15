using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace PaiAirlines.Models
{
    public class City
    {
        #region Properties
        public int ID { get; set; }

        public string Name { get; set; }

        public int CntrID { get; set; }
        #endregion
    }
}
