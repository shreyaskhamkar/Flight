using Domain;
using FluentAssertions;

namespace FlightTest;

public class FlightSpecifications
{
    [Fact]
    public void Booking_reduces_the_number_of_seats()
    {
        var flight = new Flight(seatCapaity: 3);

        flight.Book("passenger@email.com", 1);

        flight.RemainingNumberOfSeats.Should().Be(2);
    }

    [Fact]
    public void Avoid_overboooking()

    {
        var flight = new Flight(seatCapaity: 3);

        var error = flight.Book("passenger.com",4);

        error.Should().BeOfType<OverbookingError>();
    }
}