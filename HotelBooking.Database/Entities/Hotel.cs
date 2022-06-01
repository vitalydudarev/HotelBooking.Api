namespace HotelBooking.Database.Entities;

public class Hotel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    public ICollection<HotelFacilityEntity> Facilities { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
