using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PaiAirlines.Models
{
    public class Booking
    {
        #region Properties

        public int ID { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public int Userid { get; set; }

        [Required]
        [Display(Name = "Fligt ID")]
        public int FlightID { get; set; }

        [Required]
        [Display(Name = "Tickets Purchased")]
        public int SeatsAmount { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; } 

        #endregion
    }
}
