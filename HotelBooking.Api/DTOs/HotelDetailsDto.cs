namespace HotelBooking.Api.DTOs;

public class HotelDetailsDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    
    public ICollection<RoomDto> Rooms { get; set; }
    public ICollection<FacilityDto> Facilities { get; set; }
}