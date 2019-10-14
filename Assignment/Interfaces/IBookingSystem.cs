using System;

namespace BookingService
{
    
    public interface IBookingSystem
    {
        Booking FetchBooking(Guid bookingId);
        void AddGuestToBooking(Guid bookingId, Guest guest);
    }
}

