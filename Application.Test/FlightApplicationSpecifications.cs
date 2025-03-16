using FluentAssertions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Test
{
    public class FlightApplicationSpecifications
    {

        readonly Entites entities =   new Entites(new DbContextOptionsBuilder<Entites>().UseInMemoryDatabase("Flights").Options);

        readonly BookingService bookingService;


        public FlightApplicationSpecifications()
        {
            bookingService = new BookingService(entities: entities);
        }
        [Theory]
        [InlineData("M@m.com",2)]
        [InlineData("a@a.com",2)]
        //G W T
        public void Books_flights(string passengerEmail, int numberOfSeats )
        {
            var flight = new Flight(3);

            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(
                flightId:flight.Id, passengerEmail, numberOfSeats
                ));
            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf( new BookingRm(passengerEmail, numberOfSeats));
        }


        [Theory]
        [InlineData(3)]

        public void Cancel_booking(int intitalCapacity)
        {
            // Given
            var flight = new Flight(intitalCapacity);

            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(flightId:flight.Id, passengerEmail:"m@M.com", numberOfSeats:2 ));
            // When
            bookingService.CancelBooking(
                new CancelBookigDto(flightId: flight.Id, passengerEmail:"m@a.com", numberOfSeats:2)
                );
            // then

            bookingService.GetRemaingNumberOfSeatFor(flight.Id)
                .Should().Be(intitalCapacity);

        }
    }

   
}





    

