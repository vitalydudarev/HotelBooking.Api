using HotelBooking.Domain.Models;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using HotelBooking.Services.Caches;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Services.Services;

public class HotelService : IHotelService
{
    private readonly ILogger<HotelService> _logger;
    private readonly IHotelRepository _hotelRepository;
    private readonly IHotelCache _hotelCache;

    public HotelService(ILogger<HotelService> logger, IHotelRepository hotelRepository, IHotelCache hotelCache)
    {
        _logger = logger;
        _hotelRepository = hotelRepository;
        _hotelCache = hotelCache;

        // use cache for fast accessing "static" hotel data
        InitCache();
    }

    public IEnumerable<Hotel> GetHotels(int pageNumber, int pageSize)
    {
        return _hotelCache.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
    
    public async Task<Hotel> GetHotelDetailsAsync(long id)
    {
        return await _hotelRepository.GetHotelDetailsAsync(id);
    }

    public IEnumerable<Hotel> GetPopularHotels()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hotel> GetRecommendedHotels()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Hotel> GetTopRatedHotels()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Hotel>> SearchHotelAsync(string query)
    {
        _logger.LogInformation("Executing hotel search by query {Query}", query);
        
        return await Task.Run(() =>
        {
            var result = new List<Hotel>();

            foreach (var hotel in _hotelCache.GetAll())
            {
                // Contains is not the best solution for text search
                if (hotel.Name.Contains(query) || hotel.Address.Contains(query))
                {
                    result.Add(hotel);
                }
            }

            return result;
        });
    }

    public IEnumerable<string> GetTopDestinations()
    {
        throw new NotImplementedException();
    }

    private void InitCache()
    {
        _logger.LogInformation("Initializing cache");
        
        var hotels = _hotelRepository.GetHotels();
        
        foreach (var hotel in hotels)
        {
            _hotelCache.Add(hotel.Id, hotel);
        }
        
        _logger.LogInformation("Initialized cache");
    }
}
