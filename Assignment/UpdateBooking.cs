using Assignment.Interfaces;
using BookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment
{
    public class UpdateBooking : IUpdateBooking
    {
        public void AddGuestToBooking(Guid bookingId, Guest guest)
         => throw new NotImplementedException();
        public Booking FetchBooking(Guid bookingId)
            => throw new NotImplementedException();

        public void HandleNewGuest(Guid bookingId, Guest guest)
        {
            var booking = FetchBooking(bookingId);
            var validated = ValidateData(booking, guest);
            var enoughRoom = ValidateEnoughRoomInRoom(booking.RoomType, booking.Guests.Count());
            if (validated && enoughRoom)
                AddGuestToBooking(bookingId, guest);
        }

        public bool ValidateData(Booking booking, Guest guest)
        {
            var bookingOk = ValidateBooking(booking);
            var newGuestOk = ValidateNewGuest(booking.Hotel.CountryCode.ToString(), guest);
            return bookingOk && newGuestOk;
        }

        public bool ValidateBooking(Booking booking)
        {
            if (!(booking != null &&
                booking?.Guests?.Any() != null &&
                booking?.Hotel != null &&
                !string.IsNullOrEmpty(booking.RoomType)))
            {
                return false;
            }
            return true;
        }

        public bool ValidateEnoughRoomInRoom(string roomType, int guestCountBeforeAdd)
        {
            var enoughForOneMore = false;
            switch (roomType)
            {
                case nameof(RoomType.SINGLE):
                    enoughForOneMore = (guestCountBeforeAdd + 1) <= RoomType.SINGLE;
                    break;
                case nameof(RoomType.DOUBLE):
                case nameof(RoomType.TWIN):
                    enoughForOneMore = (guestCountBeforeAdd + 1) <= RoomType.DOUBLE;
                    break;
                case nameof(RoomType.TRIPLE):
                    enoughForOneMore = (guestCountBeforeAdd + 1) <= RoomType.TRIPLE;
                    break;
                default:
                    break;
            }
            return enoughForOneMore;
        }

        public bool ValidateNewGuest(string countryCode, in Guest guest)
        {
            if (!(guest != null &&
                !string.IsNullOrEmpty(countryCode) &&
                !string.IsNullOrEmpty(guest.FirstName) &&
                !string.IsNullOrEmpty(guest.LastName)))
            {
                return false;
            }

            if (countryCode == Country.DE.ToString() &&
                string.IsNullOrEmpty(guest.Title))
            {
                return false;
            }

            return true;
        }

        

        public static class RoomType
        {
            public const int SINGLE = 1;
            public const int DOUBLE = 2;
            public const int TWIN = 2;
            public const int TRIPLE = 3;
        }
    }
}