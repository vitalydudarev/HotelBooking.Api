namespace HotelBooking.Database.Entities;

public class Reservation
{
    public long Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    
    public long RoomId { get; set; }
    public Room Room { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
}