using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Models
{
    public class TicketsInBooking
    {
        public Ticket Tckt { get; set; }

        public Booking Bkng { get; set; }
    }
}
