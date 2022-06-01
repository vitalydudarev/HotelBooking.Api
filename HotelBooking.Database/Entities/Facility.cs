namespace HotelBooking.Database.Entities;

public class Facility
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    
    public List<HotelFacility> Facilities { get; set; }
}
