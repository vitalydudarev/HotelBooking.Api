using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Services;

public interface IHotelService
{
    IEnumerable<Hotel> GetHotels(int pageNumber, int pageSize);
    Task<Hotel> GetHotelDetailsAsync(long id);
    IEnumerable<Hotel> GetPopularHotels();
    IEnumerable<Hotel> GetRecommendedHotels();
    Task<IEnumerable<Hotel>> GetTopRatedHotelsAsync();
    Task<IEnumerable<Hotel>> SearchHotelAsync(string query);
    IEnumerable<string> GetTopDestinations();
}
