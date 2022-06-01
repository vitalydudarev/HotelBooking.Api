namespace HotelBooking.Database.Entities;

public class HotelFacility
{
    public long HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public long FacilityId { get; set; }
    public Facility Facility { get; set; }
}
