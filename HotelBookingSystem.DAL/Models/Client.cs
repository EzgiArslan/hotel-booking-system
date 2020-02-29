using System;
using System.Collections.Generic;

namespace HotelBookingSystem.DAL.Models
{
    public partial class Client
    {
        public Client()
        {
            Booking = new HashSet<Booking>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
