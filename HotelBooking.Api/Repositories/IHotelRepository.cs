using HotelBooking.Api.Database.Entities;

namespace HotelBooking.Api.Repositories;

public interface IHotelRepository
{
    Task<IEnumerable<HotelEntity>> GetHotelsAsync(PaginationParameters? paginationParameters);
    IEnumerable<HotelEntity> GetHotels();
}
