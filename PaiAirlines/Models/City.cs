using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace PaiAirlines.Models
{
    public class City
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }
        #endregion
    }
}
