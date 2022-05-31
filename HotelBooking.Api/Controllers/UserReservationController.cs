using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/user/{userId}/reservations")]
public class UserReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public UserReservationController(IReservationService reservationService, IMapper mapper)
    {
        _reservationService = reservationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OutgoingReservationDto>))]
    public async Task<IActionResult> GetUserReservations(long userId)
    {
        var reservations = await _reservationService.GetUserReservationsAsync(userId);
        var resultDto = _mapper.Map<IEnumerable<OutgoingReservationDto>>(reservations);
        
        return Ok(resultDto);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ReservationDetailsDto>))]
    public async Task<IActionResult> GetReservationDetails(long id)
    {
        var reservationDetails = await _reservationService.GetReservationDetailsAsync(id);
        var dto = _mapper.Map<ReservationDetailsDto>(reservationDetails);
        
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> AddReservation(long userId, [FromBody] IncomingReservationDto incomingReservation)
    {
        var reservation = _mapper.Map<Reservation>(incomingReservation);
        reservation.UserId = userId;

        await _reservationService.AddReservationAsync(reservation);

        return Ok();
    }
}
