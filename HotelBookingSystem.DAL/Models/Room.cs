using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
        }

        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int Capacity { get; set; }
        public bool Aircondition { get; set; }
        public bool Minibar { get; set; }
        public bool Television { get; set; }
        public int? Price { get; set; }

        public Hotel Hotel { get; set; }
        public ICollection<Booking> Booking { get; set; }
    }
}
