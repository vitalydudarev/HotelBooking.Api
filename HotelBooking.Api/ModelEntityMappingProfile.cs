using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;

namespace HotelBooking.Api;

public class ModelEntityMappingProfile : Profile
{
    public ModelEntityMappingProfile()
    {
        CreateMap<Hotel, HotelEntity>().ReverseMap();
        CreateMap<Reservation, OutgoingReservationDto>();
        CreateMap<IncomingReservationDto, Reservation>();
    }
}
