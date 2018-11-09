using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiAirlines.Models;
using Microsoft.AspNetCore.Http;

namespace PaiAirlines.Controllers
{
    public class BookingsController : Controller
    {
        private readonly PaiDBContext _context;

        public BookingsController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return View(await _context.Booking.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .SingleOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TotalPrice")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.SingleOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TotalPrice")] Booking booking)
        {
            if (id != booking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .SingleOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.SingleOrDefaultAsync(m => m.ID == id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID == id);
        }

        // GET: Bookings
        public async Task<IActionResult> myFlights()
        {
            ViewData["CityList"] = _context.City.ToList<City>();
            if (HttpContext.Session.GetString("ID") != null)
            {
                // Creates a Join statement which returns the flights belongs to current user by his bookings
                List<Flight> lstFlights = await _context.Booking.Where(book => book.Userid == int.Parse(HttpContext.Session.GetString("ID"))).Join(_context.Flight,
                                                                                                                                        bkg => bkg.FlightID,
                                                                                                                                        flt => flt.ID,
                                                                                                                                        (bkg, flt) => new Flight
                                                                                                                                        {
                                                                                                                                            ID = flt.ID,
                                                                                                                                            FlightNumber = flt.FlightNumber,
                                                                                                                                            DestinationId = flt.DestinationId,
                                                                                                                                            OriginId = flt.OriginId,
                                                                                                                                            Price = bkg.TotalPrice,
                                                                                                                                            Seats = bkg.SeatsAmount,
                                                                                                                                            Time = flt.Time
                                                                                                                                        })
                                                                                                                                        .ToListAsync();

                Dictionary<int, KeyValuePair<Flight,int>> dictDistinct = new Dictionary<int, KeyValuePair<Flight, int>>();
                foreach (Flight flt in lstFlights)
                {
                    //if(dictDistinct.Keys.ToList().Count(firstFlight => flt.ID == firstFlight.ID) != 0)
                    if(dictDistinct.ContainsKey(flt.ID))
                    {
                        Flight tempFlight = dictDistinct[flt.ID].Key;
                        tempFlight.Price += flt.Price;
                        dictDistinct[flt.ID] = new KeyValuePair<Flight, int>(tempFlight, dictDistinct[flt.ID].Value+1); 
                    }
                    else
                    {
                        dictDistinct[flt.ID] = new KeyValuePair<Flight, int>(flt, 1);
                    }
                }

                List <Flight> lstTemp = new List<Flight>();

                foreach (KeyValuePair<Flight,int> flt in dictDistinct.Values)
                {
                    lstTemp.Add(flt.Key);
                }

                ViewData["DistinctsFlights"] = dictDistinct.Values.ToList();
                return View(lstTemp);
            }
            return RedirectToAction("NoAccess", "Home");
        }
    }
}
;