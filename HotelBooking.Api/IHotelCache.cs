using HotelBooking.Api.Models;

namespace HotelBooking.Api;

public interface IHotelCache
{
    void Add(long id, Hotel hotel);
    void Remove(long id);
    Hotel Get(long id);
    IEnumerable<Hotel> GetAll();
}