using AutoMapper;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Database.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly DatabaseContext _context;
    private readonly IMapper _mapper;

    public ReservationRepository(IMapper mapper, DatabaseContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId)
    {
        var reservations = await _context.Reservations.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();

        return _mapper.Map<IEnumerable<Reservation>>(reservations);
    }
    
    public async Task<Reservation> GetReservationDetailsAsync(long id)
    {
        var reservations = await _context.Reservations
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Include(b => b.Room)
            .FirstOrDefaultAsync();
        
        return _mapper.Map<Reservation>(reservations);
    }
    
    public async Task AddReservationAsync(Reservation reservation)
    {
        var dbReservation = _mapper.Map<Entities.Reservation>(reservation);
        
        await _context.Reservations.AddAsync(dbReservation);
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
