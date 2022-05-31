using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.DTOs;
using HotelBooking.Api.Models;

namespace HotelBooking.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelEntity>().ReverseMap();
        CreateMap<Reservation, OutgoingReservationDto>();
        CreateMap<IncomingReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDetails>();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<ReservationDetails, ReservationDetailsDto>().ReverseMap();
    }
}
