using AutoMapper;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Database.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public HotelRepository(IMapper mapper, DatabaseContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Hotel>> GetHotelsAsync(PaginationParameters? paginationParameters)
    {
        var queryable = _context.Hotels.AsNoTracking().OrderBy(a => a.Id).AsQueryable();

        if (paginationParameters != null)
        {
            queryable = queryable
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        var hotels = await queryable.ToListAsync();
        
        return _mapper.Map<IEnumerable<Hotel>>(hotels);
    }
    
    public IEnumerable<Hotel> GetHotels()
    {
        var hotels = _context.Hotels.AsNoTracking().OrderBy(a => a.Id).ToList();
        
        return _mapper.Map<IEnumerable<Hotel>>(hotels);
    }
}
