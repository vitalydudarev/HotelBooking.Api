using HotelBooking.Api.Models;
using HotelBooking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Hotel>))]
    public IActionResult Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var hotels = _hotelService.GetHotels(pageNumber, pageSize);

        return Ok(hotels);
    }
}
