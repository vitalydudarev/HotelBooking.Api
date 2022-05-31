using HotelBooking.Api.Database.Entities;

namespace HotelBooking.Api.Models;

public class ReservationDetails
{
    public long Id { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public long TotalPrice { get; set; }
    public Room Room { get; set; }
}
