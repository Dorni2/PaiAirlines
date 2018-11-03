using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PaiAirlines.Models
{
    public class Flight
    {
        #region Properties

        // Flight ID, primary key.
        public int ID { get; set; }

        // Flight number. e.g. (pai)058
        [Required]
        [Range(0, 9999)]
        [Display(Name = "Flight Number")]
        public int FlightNumber { get; set; }

        // Id of origin. e.g. for TLV, id=4
        [Required]
        [Display(Name = "Origin ID")]
        public int OriginId { get; set; }

        // Id of destination. e.g. for TLV, id=4
        [Required]
        [Display(Name = "Destination ID")]
        public int DestinationId { get; set; }

        [Required]
        [Range(0, 538)]
        [Display(Name = "Destination ID")]
        public int Seats { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        public DateTime Time { get; set; }

        [Required]
        [Range(0, 9999)]
        public int Price { get; set; }

        #endregion
    }
}
