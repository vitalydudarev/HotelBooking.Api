namespace HotelBooking.Domain.Models;

public class RoomType
{
    public long Id { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public bool SmokingAllowed { get; set; }
}