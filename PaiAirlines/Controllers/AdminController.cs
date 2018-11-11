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
    public class AdminController : Controller
    {
        private readonly PaiDBContext _context;

        public AdminController(PaiDBContext context)
        {
            _context = context;
        }




        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,CntryID,CtyID,Street,Phone,IsAdmin,IsMatmid,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,CntryID,CtyID,Street,Phone,IsAdmin,IsMatmid,Email,Password")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(m => m.ID == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.ID == id);
        }

        // GET: Admin/Create
        public IActionResult AdminStuff()
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            ViewData["Cities"] = _context.City.ToList();
            ViewData["FlightBooking"] = _context.Flight.Join(_context.Booking,
                                flt => flt.ID,
                                bkg => bkg.FlightID,
                                (flt, bkg) => new Flight
                                {
                                    OriginId = flt.OriginId,
                                    DestinationId = flt.DestinationId,
                                    Price = bkg.TotalPrice,
                                    Time = flt.Time
                                })
                                .ToList();

            Dictionary<City, int> dictCityGroups = new Dictionary<City, int>();
            List<City> lstCities = _context.City.ToList();
            List<object> temp = new List<object>();
            _context.Flight.GroupBy(flt => flt.DestinationId).Select(g => new 
            {
                ID = g.Key,
                CountA = g.Count()
            }).ToList().ForEach(freq => dictCityGroups.Add(lstCities.Find(ct => ct.ID == freq.ID), freq.CountA));
            ViewData["Citygroups"] = dictCityGroups;
            return View();
        }
    }
}
