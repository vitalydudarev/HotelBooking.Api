using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.Models;
using HotelBooking.Domain.Repositories;
using HotelBooking.Services.Caches;
using HotelBooking.Services.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Services.Tests;

public class HotelServiceTests
{
    private readonly Mock<IHotelRepository> _repositoryMock;
    private readonly Mock<IHotelCache> _hotelCache;
    private readonly NullLogger<HotelService> _logger;

    public HotelServiceTests()
    {
        _repositoryMock = new Mock<IHotelRepository>();
        _hotelCache = new Mock<IHotelCache>();
        _logger = new NullLogger<HotelService>();
    }
    
    [Theory]
    [InlineData("Cairo", 1)]
    [InlineData("Radisson", 2)]
    [InlineData("Dubai", 2)]
    [InlineData("Washington", 0)]
    public async Task SearchHotelAsync_ShouldWorkCorrectly(string query, int expectedResults)
    {
        // Arrange
        var hotels = new List<Hotel>()
        {
            new() {Name = "Radisson", Address = "Dubai"},
            new() {Name = "Radisson", Address = "Minsk"},
            new() {Name = "Plaza", Address = "Cairo"},
            new() {Name = "Plaza", Address = "Dubai"},
        };
        
        _hotelCache.Setup(a => a.GetAll()).Returns(hotels);
        
        var service = new HotelService(_logger, _repositoryMock.Object, _hotelCache.Object);
        
        // Act
        var result = await service.SearchHotelAsync(query);
        
        // Assert
        Assert.Equal(expectedResults, result.Count());
    }
}
