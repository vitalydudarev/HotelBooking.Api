namespace HotelBooking.Api.DTOs;

public class ReservationDetailsDto
{
    public long Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public long TotalPrice { get; set; }
    public RoomDto Room { get; set; }
}
