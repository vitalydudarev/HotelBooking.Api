using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Repositories;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetHotelsAsync(PaginationParameters? paginationParameters);
    IEnumerable<Hotel> GetHotels();
    Task<Hotel> GetHotelDetailsAsync(long id);
    Task<IEnumerable<Hotel>> GetHotelsWithReviewsAsync();
}
