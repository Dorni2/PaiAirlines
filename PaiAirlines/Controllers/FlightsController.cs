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
    public class FlightsController : Controller
    {
        private readonly PaiDBContext _context;

        public FlightsController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flight.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            ViewData["Citylist"] = _context.City.ToList();
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FlightNumber,OriginId,DestinationId,Time,Price")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        //// POST: Flights/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,FlightNumber,Time,Price")] Flight flight)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(flight);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(flight);
        //}

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FlightNumber,Time,Price")] Flight flight)
        {
            if (id != flight.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.ID))
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
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID == id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.ID == id);
        }

        // GET: Flights/Search
        public async Task<IActionResult> Search(int CityId, int OrigID, int Max, DateTime FlightDate)
        {
            ViewData["Citylist"] = _context.City.ToList();
            List<Flight> lstFilter  = _context.Flight.ToList();
            //if (CityId != null && CityId != 0)
            //{
            //    return View(_context.Flight.Where(flt => flt.DestinationId == CityId).ToList());
            //}
            if (CityId != null && CityId != 0)
            {
                lstFilter = lstFilter.Where(flt => flt.DestinationId == CityId).ToList();
            }
            if (OrigID != null && OrigID != 0)
            {
                lstFilter = lstFilter.Where(flt => flt.OriginId == OrigID).ToList();
            }
            if (Max != null && Max != 0)
            {
                lstFilter = lstFilter.Where(flt => flt.Price <= Max).ToList();
            }
            if (FlightDate >= DateTime.Today)
            {
                lstFilter = lstFilter.Where(flt => flt.Time.Date == FlightDate.Date).ToList();
            }

            return View(lstFilter);
        }

        public async Task<IActionResult> Order (int id)
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                Booking bkng = new Booking();
                bkng.Userid = int.Parse(HttpContext.Session.GetString("ID"));
                bkng.FlightID = id;
                bkng.TotalPrice = _context.Flight.Single(flt => flt.ID == id).Price;
                _context.Booking.Add(bkng);
                _context.SaveChangesAsync();
                return RedirectToAction("index", "Home");
            }

            
        }

    }
}
