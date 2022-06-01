using AutoMapper;
using HotelBooking.Api.DTOs;
using HotelBooking.Domain.Models;

namespace HotelBooking.Api.Mappers;

public class ModelDtoMappingProfile : Profile
{
    public ModelDtoMappingProfile()
    {
        CreateMap<Reservation, ReservationDetails>();
        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<ReservationDetails, ReservationDetailsDto>().ReverseMap();
        CreateMap<Reservation, OutgoingReservationDto>();
        CreateMap<IncomingReservationDto, Reservation>();
        CreateMap<Hotel, HotelDetailsDto>().ForMember(a => a.Facilities,
            expression => expression.MapFrom(b => b.HotelFacilities.Select(c => c.Facility)));
        CreateMap<Facility, FacilityDto>();

        CreateMap<Reservation, ReservationDetails>();
    }
}
