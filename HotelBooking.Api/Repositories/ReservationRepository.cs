using HotelBooking.Api.Database;
using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DatabaseContext _context;

    public ReservationRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Reservation> GetReservationDetailsAsync(long id)
    {
        return await _context.Reservations
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Include(b => b.Room)
            .FirstOrDefaultAsync();
    }
}
