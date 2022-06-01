using AutoMapper;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Services.Services;

public class ReservationService : IReservationService
{
    private readonly ILogger<HotelService> _logger;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public ReservationService(
        ILogger<HotelService> logger,
        IMapper mapper,
        IReservationRepository reservationRepository)
    {
        _logger = logger;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Reservation>> GetUserReservationsAsync(long userId)
    {
        _logger.LogInformation("Retrieving user {UserId} reservations", userId);
        
        return await _reservationRepository.GetUserReservationsAsync(userId);
    }
    
    public async Task<ReservationDetails> GetReservationDetailsAsync(long id)
    {
        _logger.LogInformation("Retrieving reservation details for reservation {Id}", id);
        
        var reservation = await _reservationRepository.GetReservationDetailsAsync(id);
        var totalDays = (reservation.EndDate - reservation.StartDate).Days;
        var totalPrice = reservation.Room.Price * totalDays;

        var reservationDetails = _mapper.Map<ReservationDetails>(reservation);
        reservationDetails.TotalPrice = totalPrice;
        
        _logger.LogInformation("Retrieved reservation details for reservation {Id}", id);
        
        return reservationDetails;
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        _logger.LogInformation("Adding reservation for user {UserId}", reservation.UserId);
        
        await _reservationRepository.AddReservationAsync(reservation);
        
        _logger.LogInformation("Added reservation for user {UserId}", reservation.UserId);
    }
    
    public async Task RemoveReservationAsync(long id)
    {
        _logger.LogInformation("Removing reservation {Id}", id);
        
        await _reservationRepository.RemoveReservationAsync(id);
        
        _logger.LogInformation("Removing reservation {Id}", id);
    }
}
