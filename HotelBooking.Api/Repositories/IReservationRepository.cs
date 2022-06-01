using HotelBooking.Api.Database.Entities;

namespace HotelBooking.Api.Repositories;

public interface IReservationRepository
{
    Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId);
    Task<Reservation> GetReservationDetailsAsync(long id);
    Task AddReservationAsync(Reservation reservation);
    Task RemoveReservationAsync(long id);
}
