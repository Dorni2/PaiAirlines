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
    public class AirportsController : Controller
    {
        private readonly PaiDBContext _context;

        public AirportsController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airport.ToListAsync());
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .SingleOrDefaultAsync(m => m.ID == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Coordinates,IATAcode")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(airport);
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport.SingleOrDefaultAsync(m => m.ID == id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Coordinates,IATAcode")] Airport airport)
        {
            if (id != airport.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.ID))
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
            return View(airport);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .SingleOrDefaultAsync(m => m.ID == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airport = await _context.Airport.SingleOrDefaultAsync(m => m.ID == id);
            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AirportExists(int id)
        {
            return _context.Airport.Any(e => e.ID == id);
        }

        // GET: Airports/Map
        public IActionResult Map()
        {
            return View();
        }

        // GET: Airports/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Airports/Search
        public async Task<IActionResult> Search([Bind("Name,IATAcode")] Airport airport)
        {
            List<Airport> lstAirports = _context.Airport.Where(currAirport => currAirport.Name == airport.Name && currAirport.IATAcode == airport.IATAcode).ToList();
            
            

            return View(lstAirports);
            
            //var airport = await _context.Airport
            //    .SingleOrDefaultAsync(m => m.ID == id);
            //if (airport == null)
            //{
            //    return NotFound();
            //}

        }
    }
}
