namespace HotelBooking.Api.Database.Entities;

public class FacilityEntity
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    
    public List<HotelFacilityEntity> Facilities { get; set; }
}
