namespace HotelBooking.Api;

public class CacheFactory
{
    public IHotelCache Create(string cacheType)
    {
        switch (cacheType)
        {
            case "Memory":
                return new HotelCache();
            default:
                throw new ArgumentNullException();
        }
    }
}