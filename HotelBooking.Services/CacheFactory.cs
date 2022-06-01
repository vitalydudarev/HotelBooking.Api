using HotelBooking.Services.Caches;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Services;

public static class CacheFactory
{
    public static void AddCacheService(string cacheType, IServiceCollection serviceCollection)
    {
        switch (cacheType)
        {
            case "Memory":
                serviceCollection.AddSingleton<IHotelCache, HotelCache>();
                break;
            default:
                throw new ArgumentNullException();
        }
    }
}