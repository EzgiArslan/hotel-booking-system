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
    public class RoomsController : Controller
    {
        private readonly HotelBookingSystemContext _context;

        public RoomsController(HotelBookingSystemContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> IndexRoom(int? id)
        {
            var hotelBookingSystemContext = _context.Room.Include(r => r.Hotel);
            if (id == null)
            {
                return NotFound();
            }
            var room = from r in _context.Room
                          select r;
            room = hotelBookingSystemContext.Where(r => r.HotelId.Equals(id));
            return View(await room.ToListAsync());
        }
        public async Task<IActionResult> IndexRoomClient(int? id)
        {
            var hotelBookingSystemContext = _context.Room.Include(r => r.Hotel);
            if (id == null)
            {
                return NotFound();
            }
            var room = from r in _context.Room
                       select r;
            room = hotelBookingSystemContext.Where(r => r.HotelId.Equals(id));
            return View(await room.ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            var hotelBookingSystemContext = _context.Room.Include(r => r.Hotel);
            return View(await hotelBookingSystemContext.ToListAsync());
        }
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,HotelId,Capacity,Aircondition,Minibar,Television")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", room.HotelId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", room.HotelId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,HotelId,Capacity,Aircondition,Minibar,Television")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "Address", room.HotelId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomId == id);
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
