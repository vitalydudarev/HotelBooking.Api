using AutoMapper;
using HotelBooking.Api.Database;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;
using HotelBooking.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Services;

public class ReservationService : IReservationService
{
    private readonly ILogger<HotelService> _logger;
    private readonly DatabaseContext _context;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(
        ILogger<HotelService> logger,
        IReservationRepository reservationRepository,
        IMapper mapper,
        DatabaseContext context)
    {
        _logger = logger;
        _reservationRepository = reservationRepository;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId)
    {
        return await _context.Reservations.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();
    }
    
    public async Task<ReservationDetails> GetReservationDetailsAsync(long reservationId)
    {
        var reservation = await _reservationRepository.GetReservationDetailsAsync(reservationId);
        var totalDays = (reservation.EndDate - reservation.StartDate).Days;
        var totalPrice = reservation.Room.Price * totalDays;

        var reservationDetails = _mapper.Map<ReservationDetails>(reservation);
        reservationDetails.TotalPrice = totalPrice;

        return reservationDetails;
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }
    
    public async Task RemoveReservation(long id)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(a => a.Id == id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
