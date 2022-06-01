using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Services;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId);
    Task AddReservationAsync(Reservation reservation);
    Task RemoveReservationAsync(long id);
    Task<ReservationDetails> GetReservationDetailsAsync(long id);
}
