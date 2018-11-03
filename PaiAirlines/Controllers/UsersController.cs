using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaiAirlines.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace PaiAirlines.Controllers
{
    public class UsersController : Controller
    {
        private readonly PaiDBContext _context;

        public UsersController(PaiDBContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
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

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Street,Phone,IsAdmin,IsMatmid")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Home", "Index");
        //    }
        //    else
        //    {

        //    }
        //    return View(user);
        //}

        // GET: Users/Edit/5
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
            ViewData["Citylist"] = _context.City.ToList();
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,Password,CtyID,IsAdmin")] User user)
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

        // GET: Users/Delete/5
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

        // POST: Users/Delete/5
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

        //
        // GET: Users/Register
        public IActionResult Register()
        {
            List<City> lstCity = _context.City.ToList<City>();
            ViewData["Citylist"] = lstCity;
            return View();
        }

        // POST: Users/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("ID,FirstName,LastName,Email,Password,CtyID")] User user)
        {
            if (ModelState.IsValid)
            {
                user.IsAdmin = false;
                //user.IsMatmid = false;
                //City city = new City();
                //city.Name = user.Cty.Name;
                //city.Cntr = user.Cntry;
                //_context.Add(city);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }


        ////
        //// GET: Users/AdminSign
        //public IActionResult AdminSign()
        //{
        //    return View();
        //}


        //// POST: Users/AdminSign
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AdminSign([Bind("Email,Password")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User admin = (User)_context.User.Where(CurrUser => user.Email == CurrUser.Email && CurrUser.IsAdmin);
        //        if (admin != null)
        //        {
        //            return RedirectToAction("AdminStuff", "Admin");
        //        }
        //        else
        //        {

        //        }
        //    }
        //    return View(user);
        //}

        //GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        //POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] User user)
        {
            User tempUser = _context.User.Single(currUser => user.Password == currUser.Password && user.Email == currUser.Email);
            if (tempUser != null)
            {
                HttpContext.Session.SetString("currUser", tempUser.FirstName);
                HttpContext.Session.SetString("ID", tempUser.ID.ToString());
                HttpContext.Session.SetString("Email", tempUser.Email);
                HttpContext.Session.SetString("isAdmin", tempUser.IsAdmin.ToString());

                return RedirectToAction("Index", "Home");
            }

            //TODO: what to return when login incorrect
            return null;

        }

        //GET: Users/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
