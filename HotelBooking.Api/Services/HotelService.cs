using AutoMapper;
using HotelBooking.Api.Models;
using HotelBooking.Api.Repositories;

namespace HotelBooking.Api.Services;

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

        InitCache();
    }

    public IEnumerable<Hotel> GetHotels(int pageNumber, int pageSize)
    {
        return _hotelCache.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize);
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
        
        var hotelEntities = _hotelRepository.GetHotels();
        var hotels = _mapper.Map<IEnumerable<Hotel>>(hotelEntities);
        
        foreach (var hotel in hotels)
        {
            _hotelCache.Add(hotel.Id, hotel);
        }
        
        _logger.LogInformation("Initialized cache");
    }
}
