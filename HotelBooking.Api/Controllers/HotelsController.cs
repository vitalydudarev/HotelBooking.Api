using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IMapper _mapper;
    
    // TODO: add pagination
    // TODO: add Hotels caching

    public HotelsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Hotel>))]
    public IActionResult Get()
    {
        var hotels = new List<HotelEntity>();
        
        hotels.Add(new HotelEntity { Id = 1, Name = "Radisson Blu", Address = "Dubai, Downtown"});

        var mapped = _mapper.Map<List<Hotel>>(hotels);

        return Ok(mapped);
    }
}
