using BookingService;
using Moq;
using Newtonsoft.Json;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Assignment.Tests
{
    public class ValidateBookingTest : IClassFixture<BookingServiceFixture>
    {
        private readonly BookingServiceFixture _fixture;
        private readonly ITestOutputHelper _output;

        public ValidateBookingTest(BookingServiceFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }
        
        [Theory]
        [InlineData("6dff2eb2-e040-4aca-a44f-bf95b9104685", "Lars")]
        [InlineData("6786f154-1663-4dbb-b282-ca033ab88386", "Knut")]
        [InlineData("d1e61835-2d25-4bf4-b9d1-a6912ca07f60", "Anna")]
        public void When_validating_booking_successfully(string bookingNumber, string guestName)
        {
            //Arrange
            Guid bookingId = Guid.Parse(bookingNumber);
            var updateBooking = new UpdateBooking();

            var moq = new Mock<IBookingSystem>();
            moq.CallBase = true;
            moq.Setup(x => x.FetchBooking(bookingId)).Returns(_fixture.GetMockBooking(bookingId));

            var booking = moq.Object.FetchBooking(bookingId);

            //Act
            var status = updateBooking.ValidateBooking(booking);

            //Assert
            _output.WriteLine(JsonConvert.SerializeObject(booking));
            Assert.True(status, "The validation failed");
        }
        [Theory]
        [InlineData("0fa6627f-9f06-4cba-a2af-b400e04e3bd6", "Petter")]
        [InlineData("1fdf8825-87a2-4ebe-8844-242e4c00070e", "Karl")]
        public void When_validate_booking_fails(string bookingNumber, string guestName)
        {
            //Arrange
            Guid bookingId = Guid.Parse(bookingNumber);
            var updateBooking = new UpdateBooking();

            var moq = new Mock<IBookingSystem>();
            moq.CallBase = true;
            moq.Setup(x => x.FetchBooking(bookingId)).Returns(_fixture.GetMockBooking(bookingId));

            var booking = moq.Object.FetchBooking(bookingId);
            //Act
            var status = updateBooking.ValidateBooking(booking);

            //Assert
            _output.WriteLine(JsonConvert.SerializeObject(booking));
            Assert.True(status, "The validation was successful");
        }
    }
}
