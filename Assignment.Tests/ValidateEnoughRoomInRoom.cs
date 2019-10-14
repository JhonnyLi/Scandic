using BookingService;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using static Assignment.UpdateBooking;

namespace Assignment.Tests
{
    public class ValidateEnoughRoomInRoom : IClassFixture<BookingServiceFixture>
    {
        private readonly BookingServiceFixture _fixture;
        private readonly ITestOutputHelper _output;

        public ValidateEnoughRoomInRoom(BookingServiceFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }

        [Theory]
        [InlineData("SINGLE",0)]
        [InlineData("DOUBLE",1)]
        [InlineData("TWIN",0)]
        [InlineData("TRIPLE", 2)]
        public void When_there_is_enough_room_for_another_guest(string roomType, int guestCount)
        {
            //Arrange
            var updateBooking = new UpdateBooking();

            //Act
            var status = updateBooking.ValidateEnoughRoomInRoom(roomType,guestCount);

            //Assert

            Assert.True(status, "The validation failed");
        }
        [Theory]
        [InlineData("SINGLE", 1)]
        [InlineData("DOUBLE", 2)]
        [InlineData("TWIN", 2)]
        [InlineData("TRIPLE", 3)]
        public void When_the_room_is_full(string roomType, int guestCount)
        {
            //Arrange
            var updateBooking = new UpdateBooking();

            //Act
            var status = updateBooking.ValidateEnoughRoomInRoom(roomType, guestCount);

            //Assert
            Assert.True(!status, "The validation was successful");
        }
    }
}
