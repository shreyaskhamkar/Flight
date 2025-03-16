using Data;
namespace Application
{
    public class BookingService
    {
        public Entites Entites { get; set; }
        public BookingService(Entites entities)
        {
            Entites = entities;
        }
        public void Book(BookDto bookDto)
        {
            var flight = Entites.Flights.Find(bookDto.FlightId);

            flight.Book(bookDto.PassengerEmail, bookDto.NumberOfSeats);

            Entites.SaveChanges();
        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return Entites.Flights
                .Find(flightId)
                .BookingList
                .Select(booking =>
                new BookingRm(
                    booking.Email, booking.NumberOfSeats
                    ));
        }

        public void CancelBooking(CancelBookigDto cancelBookigDto)
        {
            var flight = Entites.Flights.Find(cancelBookigDto);
            flight.CancelBooking(cancelBookigDto.PassengerEmail, cancelBookigDto.NumberOfSeats);

            Entites.SaveChanges();
        }

        public object GetRemaingNumberOfSeatFor(Guid flightId)
        {
            return Entites.Flights.Find(flightId).RemainingNumberOfSeats;
        }
    }
}