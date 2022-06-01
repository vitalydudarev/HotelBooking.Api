using HotelBooking.Domain.Models;

namespace HotelBooking.Services.Caches;

public interface IHotelCache
{
    void Add(long id, Hotel hotel);
    void Remove(long id);
    Hotel Get(long id);
    IEnumerable<Hotel> GetAll();
}