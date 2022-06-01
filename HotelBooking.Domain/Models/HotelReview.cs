namespace HotelBooking.Domain.Models;

public class HotelReview
{
    public long Id { get; set; }
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public string Comment { get; set; }
    public int Rate { get; set; }
}