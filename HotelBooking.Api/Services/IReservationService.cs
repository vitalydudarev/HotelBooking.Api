using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId);
    Task AddReservationAsync(Reservation reservation);
    Task RemoveReservationAsync(long id);
    Task<ReservationDetails> GetReservationDetailsAsync(long id);
}
