using System;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Api;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Repositories;
using HotelBooking.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Services.Tests;

public class ReservationServiceTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IReservationRepository> _reservationRepositoryMock;
    
    public ReservationServiceTests()
    {
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ModelEntityMappingProfile());
        });
        _mapper = mockMapper.CreateMapper();
        
        _reservationRepositoryMock = new Mock<IReservationRepository>();
    }
    
    [Fact]
    public async Task GetReservationDetailsAsync_ShouldCalculateTotalPriceCorrectly()
    {
        // Arrange
        const int pricePerNight = 50;
        
        var reservation = new Reservation
        {
            StartDate = new DateTimeOffset(new DateTime(2022, 08, 08)),
            EndDate = new DateTimeOffset(new DateTime(2022, 08, 10)),
            Room = new Room
            {
                Price = pricePerNight
            }
        };

        _reservationRepositoryMock.Setup(a => a.GetReservationDetailsAsync(It.IsAny<long>())).ReturnsAsync(reservation);

        var logger = new NullLogger<HotelService>();
        var service = new ReservationService(logger, _mapper, _reservationRepositoryMock.Object);
        
        // Act
        var reservationDetails = await service.GetReservationDetailsAsync(1);
        
        // Assert
        Assert.Equal(pricePerNight * (reservation.EndDate - reservation.StartDate).Days, reservationDetails.TotalPrice);
    }
}
