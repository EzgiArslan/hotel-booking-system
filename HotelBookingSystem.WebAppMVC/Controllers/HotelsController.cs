using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.DAL.Models;

namespace HotelBookingSystem.WebAppMVC.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelBookingSystemContext _context;

        public HotelsController(HotelBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Hotels

        public async Task<IActionResult> IndexNameForClient(string searchString)
        {
            var hotels = from h in _context.Hotel
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.HotelName.ToLower().Contains(searchString.ToLower()));
            }

            return View(await hotels.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> IndexForClient(string city,string country, int star)
        {
            var hotels = from h in _context.Hotel
                         select h;

          if (!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(country))
            {
                hotels = hotels.Where(h => h.City.ToLower().Contains(city.ToLower()) && h.Country.ToLower().Contains(country.ToLower()) && h.Star.Equals(star));
            }
          
            return View(await hotels.ToListAsync());
        }

        public async Task<IActionResult> IndexName(string searchString)
        {
            var hotels = from h in _context.Hotel
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.HotelName.ToLower().Contains(searchString.ToLower()));
            }

            return View(await hotels.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string city, string country, int star)
        {
            var hotels = from h in _context.Hotel
                         select h;

            if (!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(country))
            {
                hotels = hotels.Where(h => h.City.ToLower().Contains(city.ToLower()) && h.Country.ToLower().Contains(country.ToLower()) && h.Star.Equals(star));
            }

            return View(await hotels.ToListAsync());
        }
        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,PhoneNumber,Address,HotelName,Star,City,Country")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,PhoneNumber,Address,HotelName,Star,City,Country")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.HotelId == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int id, [Bind("HotelId,PhoneNumber,Address,HotelName,Star,City,Country")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            return View(hotel);
        }
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
    }
}
