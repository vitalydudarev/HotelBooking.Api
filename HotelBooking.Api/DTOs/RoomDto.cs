namespace HotelBooking.Api.DTOs;

public class RoomDto
{
    public long Id { get; set; }
    
    public HotelDto Hotel { get; set; }
    public int RoomNumber { get; set; }
    public string Title { get; set; }
    public long Price { get; set; }
    public RoomTypeDto RoomType { get; set; }
}
