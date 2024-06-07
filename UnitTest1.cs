using System;
using JaratKezeloProject;
using Xunit;

namespace TestJaratKezeloProject
{
    public class FlightTests
    {
        [Fact]
        public void TestFlightInitialization()
        {
            // Arrange
            string flightNumber = "AB1234";
            string departureAirport = "BUD";
            string arrivalAirport = "JFK";
            DateTime scheduledDeparture = new DateTime(2024, 6, 7, 14, 30, 0);
            TimeSpan currentDelay = TimeSpan.FromMinutes(15);

            // Act
            Flight flight = new Flight(flightNumber, departureAirport, arrivalAirport, scheduledDeparture, currentDelay);

            // Assert
            Assert.Equal(flightNumber, flight.FlightNumber);
            Assert.Equal(departureAirport, flight.DepartureAirport);
            Assert.Equal(arrivalAirport, flight.ArrivalAirport);
            Assert.Equal(scheduledDeparture, flight.ScheduledDeparture);
            Assert.Equal(currentDelay, flight.CurrentDelay);
        }
    }
}
