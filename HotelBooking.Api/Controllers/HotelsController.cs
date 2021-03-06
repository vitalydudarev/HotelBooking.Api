using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;
    private readonly IMapper _mapper;

    public HotelsController(IHotelService hotelService, IMapper mapper)
    {
        _hotelService = hotelService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HotelDto>))]
    public IActionResult Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var hotels = _hotelService.GetHotels(pageNumber, pageSize);
        var hotelDtos = _mapper.Map<IEnumerable<HotelDto>>(hotels);

        return Ok(hotelDtos);
    }
    
    [HttpGet("selection")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HotelDto>))]
    public async Task<IActionResult> GetSelection([FromQuery] string query)
    {
        if (query == "top-rated")
        {
            var hotels = await _hotelService.GetTopRatedHotelsAsync();
            var hotelDtos = _mapper.Map<IEnumerable<HotelDto>>(hotels);

            return Ok(hotelDtos);
        }
        
        return Ok(Array.Empty<HotelDto>());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelDetailsDto))]
    public async Task<IActionResult> GetHotelDetails(long id)
    {
        var hotel = await _hotelService.GetHotelDetailsAsync(id);
        var hotelDetailsDto = _mapper.Map<HotelDetailsDto>(hotel);

        return Ok(hotelDetailsDto);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HotelDto>))]
    public async Task<IActionResult> Search([FromBody] string query)
    {
        var hotel = await _hotelService.SearchHotelAsync(query);
        var hotelDetailsDto = _mapper.Map<IEnumerable<HotelDto>>(hotel);

        return Ok(hotelDetailsDto);
    }
}
