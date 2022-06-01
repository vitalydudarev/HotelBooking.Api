namespace HotelBooking.Database.Entities;

public class HotelFacilityEntity
{
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public long FacilityId { get; set; }
    public FacilityEntity Facility { get; set; }
}
