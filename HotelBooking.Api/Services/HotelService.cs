using HotelBooking.Api.Database;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Services;

public class HotelService : IHotelService
{
    private readonly ILogger<HotelService> _logger;
    private readonly DatabaseContext _context;

    public HotelService(ILogger<HotelService> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<HotelEntity>> GetHotelsAsync(int pageNumber, int pageSize)
    {
        return await _context.Hotels
            .OrderBy(a => a.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public IEnumerable<HotelEntity> GetPopularHotels()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HotelEntity> GetRecommendedHotels()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HotelEntity> GetTopRatedHotels()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HotelEntity> SearchHotel(string query)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetTopDestinations()
    {
        throw new NotImplementedException();
    }
}
