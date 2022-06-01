using System.Collections.Concurrent;
using HotelBooking.Domain.Models;

namespace HotelBooking.Services.Caches;

public class HotelCache : IHotelCache
{
    private readonly ConcurrentDictionary<long, Hotel> _cache = new();

    public void Add(long id, Hotel hotel)
    {
        _cache.TryAdd(id, hotel);
    }

    public void Remove(long id)
    {
        _cache.Remove(id, out _);
    }

    public Hotel Get(long id)
    {
        _cache.TryGetValue(id, out var hotel);

        return hotel;
    }

    public IEnumerable<Hotel> GetAll()
    {
        return _cache.Values;
    }
}