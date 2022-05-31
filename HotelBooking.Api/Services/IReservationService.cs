using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId);
    Task AddReservationAsync(Reservation reservation);
    Task RemoveReservation(long id);
    Task<ReservationDetails> GetReservationDetailsAsync(long reservationId);
}
