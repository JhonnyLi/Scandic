using BookingService;
using Moq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Assignment.Tests
{
    public class ValidateDataTest : IClassFixture<BookingServiceFixture>
    {
        private readonly BookingServiceFixture _fixture;
        private readonly ITestOutputHelper _output;

        public ValidateDataTest(BookingServiceFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }
        
        [Theory]
        [InlineData("6dff2eb2-e040-4aca-a44f-bf95b9104685", "Lars")]
        [InlineData("6786f154-1663-4dbb-b282-ca033ab88386", "Knut")]
        [InlineData("49a8b537-7166-4c85-81a5-733c5e7c0b67", "Anna")]
        public void When_validating_data_successfully(string bookingNumber, string guestName)
        {
            //Arrange
            Guid bookingId = Guid.Parse(bookingNumber);
            var updateBooking = new UpdateBooking();

            var moq = new Mock<IBookingSystem>();
            moq.CallBase = true;
            moq.Setup(x => x.FetchBooking(bookingId)).Returns(_fixture.GetMockBooking(bookingId));

            var booking = moq.Object.FetchBooking(bookingId);
            var guest = _fixture.GetMockGuest(guestName);

            //Act
            var status = updateBooking.ValidateData(booking, guest);

            //Assert

            Assert.True(status, "The validation failed");
        }
        [Theory]
        [InlineData("0fa6627f-9f06-4cba-a2af-b400e04e3bd6", "Petter")]
        [InlineData("1fdf8825-87a2-4ebe-8844-242e4c00070e", "Karl")]
        public void When_validating_data_fails(string bookingNumber, string guestName)
        {
            //Arrange
            Guid bookingId = Guid.Parse(bookingNumber);
            var updateBooking = new UpdateBooking();

            var moq = new Mock<IBookingSystem>();
            moq.CallBase = true;
            moq.Setup(x => x.FetchBooking(bookingId)).Returns(_fixture.GetMockBooking(bookingId));

            var booking = moq.Object.FetchBooking(bookingId);
            var guest = _fixture.GetMockGuest(guestName);

            //Act
            var status = updateBooking.ValidateData(booking, guest);

            //Assert

            Assert.True(!status, "The validation was successful");
        }
    }
}
