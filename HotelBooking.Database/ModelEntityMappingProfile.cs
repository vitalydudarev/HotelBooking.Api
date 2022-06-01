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
    }
}
