using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DAL.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
            Staff = new HashSet<Staff>();
        }

        public int HotelId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string HotelName { get; set; }
        public int Star { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Room> Room { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
