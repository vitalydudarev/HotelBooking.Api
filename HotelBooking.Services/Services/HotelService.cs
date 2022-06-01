using AutoMapper;
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
    private readonly IMapper _mapper;

    public HotelService(ILogger<HotelService> logger, IMapper mapper, IHotelRepository hotelRepository, IHotelCache hotelCache)
    {
        _logger = logger;
        _mapper = mapper;
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

    public IEnumerable<Hotel> SearchHotel(string query)
    {
        throw new NotImplementedException();
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
