namespace Application;

public class BookingRm
{
    #region Properties
    public string PassengerEmail { get; set; }
    public int NumberOfSeats { get; set; }
    #endregion

    #region Constructor

    public BookingRm(string passengerEmail, int numberOfSeats)
    {
        PassengerEmail = passengerEmail;
        NumberOfSeats = numberOfSeats;
    }
    #endregion
}
