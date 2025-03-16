namespace Application;

public class CancelBookigDto
{
    public string PassengerEmail { get; set; }
    public int NumberOfSeats { get; set; }
    public CancelBookigDto(Guid flightId, string passengerEmail, int numberOfSeats)
    {
        PassengerEmail = passengerEmail;
        NumberOfSeats = numberOfSeats;
    }
}
