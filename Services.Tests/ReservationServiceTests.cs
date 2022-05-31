using AutoMapper;
using HotelBooking.Api.Database.Entities;
using HotelBooking.Api.Repositories;
using HotelBooking.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Services.Tests;

public class ReservationServiceTests
{
    [Fact]
    public void Test1()
    {
        var mock = new Mock<IReservationRepository>();
        mock.Setup(a => a.GetReservationDetailsAsync(It.IsAny<long>())).ReturnsAsync(new Reservation())
        var service = new ReservationService(new NullLogger<HotelService>(), mock.Object, new Mapper(), null);
    }
}
