using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DAL.Models
{
    public partial class Booking
    {
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }

        public Client Client { get; set; }
        public Room Room { get; set; }
    }
}
