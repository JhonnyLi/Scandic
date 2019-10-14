using BookingService;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using static Assignment.UpdateBooking;

namespace Assignment.Tests
{
    public class BookingServiceFixture
    {
        private readonly List<Guest> guests;
        private readonly List<Booking> bookings;
        private readonly Dictionary<Guid, string> hotels;

        public BookingServiceFixture()
        {
            guests = AddGuests();
            bookings = AddBookings();
            hotels = new Dictionary<Guid, string>()
        {
            { Guid.Parse("6dff2eb2-e040-4aca-a44f-bf95b9104685"),"Scandic Sverige" },
            { Guid.Parse("6786f154-1663-4dbb-b282-ca033ab88386"),"Scandic Danmark" },
            { Guid.Parse("49a8b537-7166-4c85-81a5-733c5e7c0b67"),"Scandic Frankfurt" },
            { Guid.Parse("0fa6627f-9f06-4cba-a2af-b400e04e3bd6"),"Scandic Berlin" },
            { Guid.Parse("1fdf8825-87a2-4ebe-8844-242e4c00070e"),"Scandic Mora" },
            { Guid.Parse("d1e61835-2d25-4bf4-b9d1-a6912ca07f60"),"Scandic Orsa" }
                
        };

        }

        public Guest GetMockGuest(string name)
        {
            return guests.FirstOrDefault(n => n.FirstName == name);
        }

        public Booking GetMockBooking(Guid hotelGuid)
        {
            string hotelName = hotels.Single(g => g.Key.Equals(hotelGuid)).Value;
            return bookings.FirstOrDefault(hn => hn.Hotel.Name.Equals(hotelName, StringComparison.OrdinalIgnoreCase));
        }


        private List<Guest> AddGuests()
        {
            return new List<Guest>
            {
                new Guest
                {
                    FirstName = "Lars",
                    LastName = "Larsson",
                    Title = "Mr"
                },
                new Guest
                {
                    FirstName = "Knut",
                    LastName = "Knutsson",
                    Title = ""
                },
                new Guest
                {
                    FirstName = "Anna",
                    LastName = "Svensson",
                    Title = "Mrs"
                },
                new Guest
                {
                    FirstName = "Petter",
                    LastName = "Pettersson",
                    Title = ""
                },new Guest
                {
                    FirstName = "Karl",
                    LastName = "",
                    Title = "Mr"
                }
            };
        }

        private List<Booking> AddBookings()
        {
            return new List<Booking>
            {
                new Booking
                {
                    Hotel = new Hotel
                    {
                        CountryCode = Country.SE,
                        Name = "Scandic Sverige"
                    },
                    RoomType = nameof(RoomType.SINGLE),
                    Guests = new List<Guest>()
                },
                new Booking
                {
                    Hotel = new Hotel
                    {
                        CountryCode = Country.DK,
                        Name = "Scandic Danmark"
                    },
                    RoomType = nameof(RoomType.DOUBLE),
                    Guests = new List<Guest>
                    {
                        guests.First()
                    }
                },
                new Booking
                {
                    Hotel = new Hotel
                    {
                        CountryCode = Country.DE,
                        Name = "Scandic Frankfurt"
                    },
                    RoomType = nameof(RoomType.TWIN),
                    Guests = new List<Guest>
                    {
                        guests.LastOrDefault(g=>!string.IsNullOrEmpty(g.Title))
                    }
                },
                new Booking
                {
                    Hotel = new Hotel
                    {
                        CountryCode = Country.DE,
                        Name = "Scandic Berlin"
                    },
                    RoomType = nameof(RoomType.SINGLE),
                    Guests = new List<Guest>
                    {
                        guests.FirstOrDefault(g=>!string.IsNullOrEmpty(g.Title))
                    }
                },
                new Booking
                {
                    Hotel = new Hotel
                    {
                        CountryCode = Country.SE,
                        Name = "Scandic Mora"
                    },
                    RoomType = nameof(RoomType.TRIPLE),
                    Guests = new List<Guest>
                    {
                        guests.FirstOrDefault(g=>!string.IsNullOrEmpty(g.Title)),
                        guests.LastOrDefault(g=>!string.IsNullOrEmpty(g.Title))
                    }
                },
                new Booking
                {
                    Hotel = new Hotel
                    {
                        Name = "Scandic Orsa"
                    },
                    RoomType = nameof(RoomType.TWIN),
                    Guests = new List<Guest>
                    {
                        guests.LastOrDefault(g=>!string.IsNullOrEmpty(g.Title))
                    }
                }

            };
        }



    }
}