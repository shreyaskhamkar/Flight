namespace Application;

public class BookDto
{
    #region Properties
    public Guid FlightId { get; set; }
    public string PassengerEmail { get; set; }
    public int NumberOfSeats { get; set; }
    #endregion

    #region Constructor
    public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
    {
        FlightId = flightId;
        PassengerEmail = passengerEmail;
        NumberOfSeats = numberOfSeats;
    }
    #endregion
}
