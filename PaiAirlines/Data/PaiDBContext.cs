using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaiAirlines.Models;

namespace PaiAirlines.Models
{
    public class PaiDBContext : DbContext
    {
        public PaiDBContext (DbContextOptions<PaiDBContext> options)
            : base(options)
        {
        }

        public DbSet<PaiAirlines.Models.Aircraft> Aircraft { get; set; }

        public DbSet<PaiAirlines.Models.Flight> Flight { get; set; }

        public DbSet<PaiAirlines.Models.Airport> Airport { get; set; }

        public DbSet<PaiAirlines.Models.Booking> Booking { get; set; }

        public DbSet<PaiAirlines.Models.City> City { get; set; }

        public DbSet<PaiAirlines.Models.Country> Country { get; set; }

        public DbSet<PaiAirlines.Models.Price> Price { get; set; }

        public DbSet<PaiAirlines.Models.Schedule> Schedule { get; set; }

        public DbSet<PaiAirlines.Models.Ticket> Ticket { get; set; }

        public DbSet<PaiAirlines.Models.User> User { get; set; }

        public DbSet<PaiAirlines.Models.UserMatmid> UserMatmid { get; set; }

        public DbSet<PaiAirlines.Models.AircraftFlight> AircraftFlight { get; set; }

        public DbSet<PaiAirlines.Models.Seat> Seat { get; set; }
    }
}
