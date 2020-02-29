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
    public class BookingsController : Controller
    {
        private readonly HotelBookingSystemContext _context;

        public BookingsController(HotelBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var hotelBookingSystemContext = _context.Booking.Include(b => b.Client).Include(b => b.Room);
            return View(await hotelBookingSystemContext.ToListAsync());
        }

        public async Task<IActionResult> IndexBooking(int? id)
        {
            var hotelBookingSystemContext = _context.Booking.Include(b => b.Client).Include(b => b.Room);
            if(id==null)
            {
                return NotFound();
            }
            var book = from b in _context.Booking
                       select b;
            book = hotelBookingSystemContext.Where(b => b.Room.HotelId.Equals(id));
            return View(await book.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,ClientId,RoomId,CheckinDate,CheckoutDate")] Booking booking)
        {
            var book = from b in _context.Booking
                          select b;
            if (book.Any(b => b.RoomId.Equals(booking.RoomId) && b.CheckinDate.Equals(booking.CheckinDate)) && booking.CheckoutDate.Equals(booking.CheckoutDate))
            {
                return StatusCode(406, "The room is invalid at this times.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", booking.ClientId);
                ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", booking.RoomId);
                return View(booking);
            }
            
        }
        public IActionResult CreateBook(int? id, [Bind("BookId,ClientId,RoomId,CheckinDate,CheckoutDate")] Booking booking)
        {
            var book = from b in _context.Booking
                       select b;
            if (book.Any(b => b.RoomId.Equals(booking.RoomId) && b.CheckinDate.Equals(booking.CheckinDate)) && booking.CheckoutDate.Equals(booking.CheckoutDate))
            {
                return StatusCode(406, "The room is invalid at this times.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(booking);
                   // await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", booking.ClientId);
                ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", booking.RoomId);
                return View(booking);
            }
        }
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", booking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", booking.RoomId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,ClientId,RoomId,CheckinDate,CheckoutDate")] Booking booking)
        {
            if (id != booking.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", booking.ClientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", booking.RoomId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookId == id);
        }
    }
}
