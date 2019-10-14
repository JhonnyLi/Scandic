using System.Collections.Generic;

namespace BookingService
{
    public class Booking
    {
        public IEnumerable<Guest> Guests { get; set; }
        public string RoomType { get; set; }
        public Hotel Hotel { get; set; }
    }
}

