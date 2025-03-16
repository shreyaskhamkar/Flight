
namespace Domain;

public class Flight
{
    List<Booking> bookingList = new();

    public IEnumerable<Booking>  BookingList => bookingList;
    public int RemainingNumberOfSeats { get; set; }

    public Guid Id { get; }

    [Obsolete("Needed by Ef")]
   
    public Flight()
    {
        
    }
    public Flight(int seatCapaity) 
    {
        RemainingNumberOfSeats = seatCapaity;
    }

    public object? Book(string passengerEmail, int numberOfSeats)
    {
        if (numberOfSeats > this.RemainingNumberOfSeats)
            return new OverbookingError();

        RemainingNumberOfSeats -= numberOfSeats;

        bookingList.Add(new Booking(passengerEmail,numberOfSeats));

        return null;
    }

    public object? CancelBooking(string passengerEmail, int numberOfSeats)
    {
        if(!bookingList.Any(booking => booking.Email == passengerEmail))
            return new BookigNotFoundError();

        RemainingNumberOfSeats += numberOfSeats;

        return null;
    }

}
