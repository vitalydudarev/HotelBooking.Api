using HotelBooking.Domain.Models;

namespace HotelBooking.Domain.Services;

public interface IHotelService
{
    IEnumerable<Hotel> GetHotels(int pageNumber, int pageSize);
    IEnumerable<Hotel> GetPopularHotels();
    IEnumerable<Hotel> GetRecommendedHotels();
    IEnumerable<Hotel> GetTopRatedHotels();
    IEnumerable<Hotel> SearchHotel(string query);
    IEnumerable<string> GetTopDestinations();
}
