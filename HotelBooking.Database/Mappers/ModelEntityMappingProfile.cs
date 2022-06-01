using AutoMapper;
using HotelBooking.Domain.Models;

namespace HotelBooking.Database.Mappers;

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
        CreateMap<HotelReview, Database.Entities.HotelReview>().ReverseMap();
    }
}
