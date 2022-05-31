namespace HotelBooking.Api.DTOs;

public class OutgoingReservationDto
{
    public long RoomId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
