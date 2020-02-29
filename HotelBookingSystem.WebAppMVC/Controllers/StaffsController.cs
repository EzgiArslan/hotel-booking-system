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
    public class StaffsController : Controller
    {
        private readonly HotelBookingSystemContext _context;

        public StaffsController(HotelBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            var hotelBookingSystemContext = _context.Staff.Include(s => s.Hotel);
            return View(await hotelBookingSystemContext.ToListAsync());
        }
        public async Task<IActionResult> Login()
        {
            var hotelBookingSystemContext = _context.Staff.Include(s => s.Hotel);
            return View(await hotelBookingSystemContext.ToListAsync());
        }
        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Hotel)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> profile(string username, string passwords)
        {
            Boolean flag = false;
            var staff = from s in _context.Staff
                          select s;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(passwords))
            {
                staff = staff.Where(h => h.Username.Equals(username) && h.Password.Equals(passwords));
                flag = true;


            }
            if(flag)
                return View(await staff.ToListAsync());
            else return StatusCode(406, "There was a problem in inputs.");
        }
        // GET: Staffs/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,HotelId,StaffName,StaffSurname,Password,Username")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", staff.HotelId);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", staff.HotelId);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,HotelId,StaffName,StaffSurname,Password,Username")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", staff.HotelId);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .Include(s => s.Hotel)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}
