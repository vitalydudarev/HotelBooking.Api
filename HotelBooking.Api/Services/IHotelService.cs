using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IHotelService
{
    IEnumerable<Hotel> GetHotels(int pageNumber, int pageSize);
    IEnumerable<Hotel> GetPopularHotels();
    IEnumerable<Hotel> GetRecommendedHotels();
    IEnumerable<Hotel> GetTopRatedHotels();
    IEnumerable<Hotel> SearchHotel(string query);
    IEnumerable<string> GetTopDestinations();
}
