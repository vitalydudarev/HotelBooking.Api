using HotelBooking.Api.Database.Entities;

namespace HotelBooking.Api.Repositories;

public interface IReservationRepository
{
    Task<Reservation> GetReservationDetailsAsync(long id);
}
