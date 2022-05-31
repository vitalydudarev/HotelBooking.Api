using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IHotelService _hotelService;

    // TODO: add pagination
    // TODO: add Hotels caching
    // TODO: add tests + repository + mocks

    public HotelsController(IMapper mapper, IHotelService hotelService)
    {
        _mapper = mapper;
        _hotelService = hotelService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Hotel>))]
    public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var hotels = await _hotelService.GetHotelsAsync(pageNumber, pageSize);
        
        var mapped = _mapper.Map<List<Hotel>>(hotels);

        return Ok(mapped);
    }
}
