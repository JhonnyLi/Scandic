using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Assignment.Tests
{
    public class ValidateNewGuest : IClassFixture<BookingServiceFixture>
    {
        private readonly BookingServiceFixture _fixture;
        private readonly ITestOutputHelper _output;

        public ValidateNewGuest(BookingServiceFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }

        [Theory]
        [InlineData("SE", "Lars")]
        [InlineData("FI", "Knut")]
        [InlineData("DK", "Anna")]
        public void When_validating_new_guest_data_is_successful(string countryCode, string guestName)
        {
            //Arrange
            var guest = _fixture.GetMockGuest(guestName);
            var updateBooking = new UpdateBooking();

            //Act
            var status = updateBooking.ValidateNewGuest(countryCode,guest);

            //Assert
            Assert.True(status, "The validation failed");
        }
        [Theory]
        [InlineData("DE", "Knut")]
        [InlineData("SE", "Karl")]
        [InlineData("FI", "Karl")]
        [InlineData("DK", "Karl")]
        public void When_validating_new_guest_data_fails(string countryCode, string guestName)
        {
            //Arrange
            var guest = _fixture.GetMockGuest(guestName);
            var updateBooking = new UpdateBooking();

            //Act
            var status = updateBooking.ValidateNewGuest(countryCode, guest);

            //Assert
            Assert.True(!status, "The validation was successful");
        }
    }
}
