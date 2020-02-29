using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DAL.Models
{
    public partial class Staff
    {
        public int StaffId { get; set; }
        public int HotelId { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public Hotel Hotel { get; set; }
    }
}
