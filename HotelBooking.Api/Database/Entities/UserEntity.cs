namespace HotelBooking.Api.Database.Entities;

public class UserEntity
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; }
}
