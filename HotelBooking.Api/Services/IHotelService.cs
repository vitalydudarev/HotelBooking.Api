using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;

namespace HotelBooking.Api.Services;

public interface IHotelService
{
    Task<IEnumerable<HotelEntity>> GetHotelsAsync(int pageNumber, int pageSize);
    IEnumerable<HotelEntity> GetPopularHotels();
    IEnumerable<HotelEntity> GetRecommendedHotels();
    IEnumerable<HotelEntity> GetTopRatedHotels();
    IEnumerable<HotelEntity> SearchHotel(string query);
    IEnumerable<string> GetTopDestinations();
}
