namespace HotelBooking.Domain.Models;

public class Reservation
{
    public long Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public long UserId { get; set; }
    public Room Room { get; set; }
}