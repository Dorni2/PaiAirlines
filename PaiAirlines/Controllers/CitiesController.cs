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
    public class CitiesController : Controller
    {
        private readonly PaiDBContext _context;

        public CitiesController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: Cities
        public async Task<IActionResult> Index(string City, string Country)
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            else
            {
                List<City> lstCity = _context.City.ToList();

                if(City != null)
                {
                    lstCity = lstCity.Where(ct => ct.Name.Split(',')[0].ToLower() == City.ToLower()).ToList();
                }
                if (Country != null)
                {
                    lstCity = lstCity.Where(ct => ct.Name.Split(',')[1].ToLower() == Country.ToLower()).ToList();
                }


                return View(lstCity);
            }
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (isCityExist(id))
            {
                var city = await _context.City
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (city == null)
                {
                    return NotFound();
                }

                return View(city);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This City is no longer available... sorry :(" });
            }
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,CntrID")] City city)
        public async Task<IActionResult> Create(string CityName, string CountryName)
        {
            City city = new City();
            city.Name = CityName + "," + CountryName;
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (isCityExist(id))
            {
                var city = await _context.City.SingleOrDefaultAsync(m => m.ID == id);
                if (city == null)
                {
                    return NotFound();
                }
                return View(city);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This City is no longer available... sorry :(" });
            }
        }

        //// POST: Cities/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] City city)
        //{
        //    if (id != city.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(city);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CityExists(city.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(city);
        //}

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string CityName, string CountryName)
        {
            City city = new City
            {
                Name = CityName + "," + CountryName,
                ID = id

            };
            if (id != city.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.ID))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (isCityExist(id))
            {
                var city = await _context.City
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (city == null)
                {
                    return NotFound();
                }

                return View(city);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This City is no longer available... sorry :(" });
            }
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.City.SingleOrDefaultAsync(m => m.ID == id);
            _context.City.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.ID == id);
        }

        public bool isCityExist(int? CityId)
        {
            if (_context.City.Where(usr => usr.ID == CityId).Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
