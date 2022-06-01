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
    
    public async Task<Hotel> GetHotelDetailsAsync(long id)
    {
        var hotel = await _context.Hotels
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Include(c => c.Rooms)
                .ThenInclude(e => e.RoomType)
            .Include(b => b.HotelFacilities)
                .ThenInclude(d => d.Facility)
            .FirstOrDefaultAsync();
        
        return _mapper.Map<Hotel>(hotel);
    }
    
    // TODO: ideally we should add hotels ratings to HotelCache
    public async Task<IEnumerable<Hotel>> GetHotelsWithReviewsAsync()
    {
        var hotels = await _context.Hotels
            .AsNoTracking()
            .Include(a => a.Reviews)
            .ToListAsync();

        return _mapper.Map<IEnumerable<Hotel>>(hotels);
    }
}
