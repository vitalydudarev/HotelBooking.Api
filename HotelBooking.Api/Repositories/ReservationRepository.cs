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
    
    public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId)
    {
        return await _context.Reservations.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();
    }
    
    public async Task<Reservation> GetReservationDetailsAsync(long id)
    {
        return await _context.Reservations
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Include(b => b.Room)
            .FirstOrDefaultAsync();
    }
    
    public async Task AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }
    
    public async Task RemoveReservationAsync(long id)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(a => a.Id == id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
