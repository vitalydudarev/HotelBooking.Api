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
    
    public async Task<IEnumerable<HotelEntity>> GetHotelsAsync(PaginationParameters? paginationParameters)
    {
        var queryable = _context.Hotels.AsNoTracking().OrderBy(a => a.Id).AsQueryable();

        if (paginationParameters != null)
        {
            queryable = queryable
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }
        
        return await queryable.ToListAsync();
    }
    
    public IEnumerable<HotelEntity> GetHotels()
    {
        return _context.Hotels.AsNoTracking().OrderBy(a => a.Id).ToList();
    }
}
