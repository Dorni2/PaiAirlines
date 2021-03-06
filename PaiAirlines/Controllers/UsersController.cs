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
using PaiAirlines.Services;

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
        public async Task<IActionResult> Index(string First, string Last, string Email)
        {
            if (HttpContext.Session.GetString("isAdmin") != true.ToString())
            {
                return RedirectToAction("NoAccess", "Home");
            }
            else
            {
                List<User> lstUsers = _context.User.ToList();
                if (First != null)
                {
                    lstUsers = lstUsers.Where(usr => usr.FirstName == First).ToList();
                }
                if (Last != null)
                {
                    lstUsers = lstUsers.Where(usr => usr.LastName == Last).ToList();
                }
                if (Email != null)
                {
                    lstUsers = lstUsers.Where(usr => usr.Email == Email).ToList();
                }

                return View(lstUsers);
            }
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (isUserExist(id))
            {
                var user = await _context.User
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This user is no longer available... sorry :(" });
            }
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
            if (isUserExist(id))
            {
                var user = await _context.User.SingleOrDefaultAsync(m => m.ID == id);
                if (user == null)
                {
                    return NotFound();
                }
                ViewData["Citylist"] = _context.City.ToList();
                return View(user);
            }
            else
            {
                return RedirectToAction("OperationError", "Home", new { Alert = "This user is no longer available... sorry :(" });
            }
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
            if (isUserExist(id))
            {
                var user = await _context.User
                    .SingleOrDefaultAsync(m => m.ID == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            else
            {
                    return RedirectToAction("OperationError", "Home", new { Alert = "This user is no longer available... sorry :(" });
            }
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

        // GET: Users
        public async Task<IActionResult> Recommend()
        {
            if (HttpContext.Session.GetString("ID") == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            else
            {
                ViewData["Citylist"] = _context.City.ToList();
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
                KNN userKnn = new KNN(lstFlights, 3, _context.Flight.ToList());
                List<Flight> lstResult = userKnn.Run();
                return View(lstResult);
            }
        }

        public bool isUserExist(int? UserID)
        {
            if (_context.User.Where(usr => usr.ID == UserID).Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
