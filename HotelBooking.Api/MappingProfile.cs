using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Models;

namespace HotelBooking.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelEntity>().ReverseMap();
    }
}
