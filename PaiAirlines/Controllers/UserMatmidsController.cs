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
    public class UserMatmidsController : Controller
    {
        private readonly PaiDBContext _context;

        public UserMatmidsController(PaiDBContext context)
        {
            _context = context;    
        }

        // GET: UserMatmids
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserMatmid.ToListAsync());
        }

        // GET: UserMatmids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatmid = await _context.UserMatmid
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userMatmid == null)
            {
                return NotFound();
            }

            return View(userMatmid);
        }

        // GET: UserMatmids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserMatmids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Miles,ID,FirstName,LastName,Street,Phone,IsAdmin,IsMatmid")] UserMatmid userMatmid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userMatmid);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userMatmid);
        }

        // GET: UserMatmids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatmid = await _context.UserMatmid.SingleOrDefaultAsync(m => m.ID == id);
            if (userMatmid == null)
            {
                return NotFound();
            }
            return View(userMatmid);
        }

        // POST: UserMatmids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Miles,ID,FirstName,LastName,Street,Phone,IsAdmin,IsMatmid")] UserMatmid userMatmid)
        {
            if (id != userMatmid.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMatmid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMatmidExists(userMatmid.ID))
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
            return View(userMatmid);
        }

        // GET: UserMatmids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userMatmid = await _context.UserMatmid
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userMatmid == null)
            {
                return NotFound();
            }

            return View(userMatmid);
        }

        // POST: UserMatmids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMatmid = await _context.UserMatmid.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserMatmid.Remove(userMatmid);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserMatmidExists(int id)
        {
            return _context.UserMatmid.Any(e => e.ID == id);
        }
    }
}
