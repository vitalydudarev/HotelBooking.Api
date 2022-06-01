namespace HotelBooking.Domain.Models;

public class Hotel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
    public ICollection<HotelFacility> HotelFacilities { get; set; }
    public ICollection<HotelReview> Reviews { get; set; }
}
