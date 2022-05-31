namespace HotelBooking.Api.DTOs;

public class IncomingReservationDto
{
    public long RoomId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
