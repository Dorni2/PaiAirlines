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
        public async Task<IActionResult> Index(int CityId, int OrigID, int Max, DateTime FlightDate)
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            else
            {
                ViewData["Citylist"] = _context.City.ToList();
                List<Flight> lstFilter = _context.Flight.ToList();
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

                ViewData["Citylist"] = _context.City.ToList();
                return View(lstFilter);
            }
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (isFlightExist(id))
            {
                var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID == id);
                if (flight == null)
                {
                    return NotFound();
                }

                return View(flight);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This flight is no longer available... sorry :(" });
            }
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            ViewData["Citylist"] = _context.City.ToList();
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FlightNumber,OriginId,DestinationId,Time,Price,Seats")] Flight flight)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
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

            if (isFlightExist(id))
            {
                var flight = await _context.Flight.SingleOrDefaultAsync(m => m.ID == id);
                if (flight == null)
                {
                    return NotFound();
                }

                ViewData["Citylist"] = _context.City.ToList();
                return View(flight);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This flight is no longer available... sorry :(" });
            }
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FlightNumber,OriginId,DestinationId,Time,Price,Seats")] Flight flight)
        {
            if (id != flight.ID)
            {
                return NotFound();
            }
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

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (isFlightExist(id))
            {
                var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.ID == id);
                if (flight == null)
                {
                    return NotFound();
                }

                return View(flight);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This flight is no longer available... sorry :(" });
            }
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Flight flt = await _context.Flight.SingleOrDefaultAsync(m => m.ID == id);
            await _context.Booking.ForEachAsync(bkg =>
             {
                 if (bkg.FlightID == flt.ID)
                 {
                     _context.Booking.Remove(bkg);
                 }
             });
                _context.Flight.Remove(flt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.ID == id);
        }

        // GET: Flights/Search
        //[HttpGet]
        public async Task<IActionResult> Search(int CityId, int OrigID, int Max, DateTime FlightDate)
        {
            ViewData["Citylist"] = _context.City.ToList();
            Dictionary<int, int> dictOpenSeats = new Dictionary<int, int>();
            List<Flight> lstFilter  = _context.Flight.ToList();
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

            foreach(Flight flt in lstFilter)
            {
                dictOpenSeats.Add(flt.ID, (flt.Seats - _context.Booking.Count(bkg => bkg.FlightID == flt.ID)));
            }

            ViewData["OpenSeats"] = dictOpenSeats;
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
                if (_context.Flight.Where(flt => flt.ID == id).Count() != 0)
                {
                    Booking bkng = new Booking();
                    bkng.Userid = int.Parse(HttpContext.Session.GetString("ID"));
                    bkng.FlightID = id;
                    bkng.SeatsAmount = 1;
                    bkng.TotalPrice = _context.Flight.Single(flt => flt.ID == id).Price;
                    _context.Booking.Add(bkng);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    return RedirectToAction("OperationError", "Home", new { Alert = "This flight is no longer available... sorry :(" });
                }
            }

        }

        public bool isFlightExist(int? FlightId)
        {
            if (_context.Flight.Where(flt => flt.ID == FlightId).Count() != 0)
            {
                return true;
            }
            return false;
        }

    }
}
