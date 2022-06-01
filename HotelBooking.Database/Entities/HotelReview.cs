namespace HotelBooking.Database.Entities;

public class HotelReview
{
    public long Id { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public string Comment { get; set; }
    public int Rate { get; set; }
}