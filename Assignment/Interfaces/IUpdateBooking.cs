using BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Interfaces
{
    interface IUpdateBooking : IBookingSystem
    {
        void HandleNewGuest(Guid bookingId, Guest guest);

        bool ValidateData(Booking booking, Guest guest);

        bool ValidateNewGuest(string countryCode, in Guest guest);

        bool ValidateBooking(Booking booking);

        bool ValidateEnoughRoomInRoom(string roomType, int guestCountBeforeAdd);
    }
}
