namespace HotelBooking.Database.Entities;

public class RoomType
{
    public long Id { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public bool SmokingAllowed { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
}