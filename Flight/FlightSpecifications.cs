using Domain;
using FluentAssertions;

namespace FlightTest;

public class FlightSpecifications
{
    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(6, 3, 3)]
    [InlineData(10, 6, 4)]
    public void Booking_reduces_the_number_of_seats(int seatCapacity, int numberOfSeats, int remainingNumberOfSeats)
    {
        var flight = new Flight(seatCapaity: seatCapacity);

        flight.Book("passenger@email.com", numberOfSeats);

        flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
    }

    [Fact]
    public void Avoid_overboooking()

    {
        var flight = new Flight(seatCapaity: 3);

        var error = flight.Book("passenger.com",4);

        error.Should().BeOfType<OverbookingError>();
    }

    [Fact]

    public void Book_flight_successfully()
    {
        var flight = new Flight(seatCapaity:3);
        var error = flight.Book("jannick@tutorialseu.com", 1);
        error.Should().BeNull();
    }

    [Fact]
    public void Remembers_bookings()
    {
        var flight = new Flight(seatCapaity: 150);

        flight.Book(passengerEmail: "a@b.com", numberOfSeats:4);

        flight.BookingList.Should().ContainEquivalentOf(new Booking("a@b.com", 4));

    }

    [Theory]
    [InlineData(3,1,1,3)]
    [InlineData(2,1,1,2)]
    [InlineData(7,5,4,6)]
    public void Canceling_booking_frees_up_the_seats(int initialCapacity , int numberOfSeatToBook, int numberOfSeatsToCancel,
        int remaingNumberOfSeats)
    {
        //given
        var flight = new Flight(initialCapacity);
        flight.Book(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatToBook);

        //when
        flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToCancel);

        //then
        flight.RemainingNumberOfSeats.Should().Be(remaingNumberOfSeats);
    }

    [Fact]
    public void Doesnt_cancel_booking_for_passengers_who_not_booked()
    {
        var flight = new Flight(3);
        var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 2);
        error.Should().BeOfType<BookigNotFoundError>();

    }

    [Fact]
    public void Return_null_when_succsessfully_cancels_a_booking()
    {
        var flight = new Flight(3);
        flight.Book(passengerEmail:"a@b.com",numberOfSeats: 1);
        var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 1);
        error.Should().BeNull();
    }
}