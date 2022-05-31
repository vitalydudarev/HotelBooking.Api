using HotelBooking.Api.Database;
using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly DatabaseContext _context;

    public HotelRepository(DatabaseContext context)
    {
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
}
