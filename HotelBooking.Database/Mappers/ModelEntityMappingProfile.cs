using AutoMapper;
using HotelBooking.Domain.Models;
using Reservation = HotelBooking.Domain.Models.Reservation;

namespace HotelBooking.Database;

public class ModelEntityMappingProfile : Profile
{
    public ModelEntityMappingProfile()
    {
        CreateMap<Reservation, Database.Entities.Reservation>().ReverseMap();
        CreateMap<Hotel, Database.Entities.Hotel>().ReverseMap();
        CreateMap<Room, Database.Entities.Room>().ReverseMap();
        CreateMap<RoomType, Database.Entities.RoomType>().ReverseMap();
        CreateMap<Facility, Database.Entities.Facility>().ReverseMap();
        CreateMap<HotelFacility, Database.Entities.HotelFacility>().ReverseMap();
    }
}
