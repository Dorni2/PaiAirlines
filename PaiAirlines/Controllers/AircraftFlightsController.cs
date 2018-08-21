using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiAirlines.Models;

namespace PaiAirlines.Controllers
{
    public class AircraftFlightsController : Controller
    {
        private readonly PaiDBContext _context;

        public AircraftFlightsController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: AircraftFlights
        public async Task<IActionResult> Index()
        {
            return View(await _context.AircraftFlight.ToListAsync());
        }

        // GET: AircraftFlights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftFlight = await _context.AircraftFlight
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aircraftFlight == null)
            {
                return NotFound();
            }

            return View(aircraftFlight);
        }

        // GET: AircraftFlights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AircraftFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EconomySeatsTaken,BussinessSeatsTaken,FirstSeatsTaken")] AircraftFlight aircraftFlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraftFlight);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(aircraftFlight);
        }

        // GET: AircraftFlights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftFlight = await _context.AircraftFlight.SingleOrDefaultAsync(m => m.ID == id);
            if (aircraftFlight == null)
            {
                return NotFound();
            }
            return View(aircraftFlight);
        }

        // POST: AircraftFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EconomySeatsTaken,BussinessSeatsTaken,FirstSeatsTaken")] AircraftFlight aircraftFlight)
        {
            if (id != aircraftFlight.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraftFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftFlightExists(aircraftFlight.ID))
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
            return View(aircraftFlight);
        }

        // GET: AircraftFlights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraftFlight = await _context.AircraftFlight
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aircraftFlight == null)
            {
                return NotFound();
            }

            return View(aircraftFlight);
        }

        // POST: AircraftFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraftFlight = await _context.AircraftFlight.SingleOrDefaultAsync(m => m.ID == id);
            _context.AircraftFlight.Remove(aircraftFlight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AircraftFlightExists(int id)
        {
            return _context.AircraftFlight.Any(e => e.ID == id);
        }
    }
}
