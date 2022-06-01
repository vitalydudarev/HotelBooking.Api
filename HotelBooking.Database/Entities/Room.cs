namespace HotelBooking.Database.Entities;

public class Room
{
    public long Id { get; set; }
    
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    
    public int RoomNumber { get; set; }
    public string Title { get; set; }
    public long Price { get; set; }
    
    public long RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; }
}
