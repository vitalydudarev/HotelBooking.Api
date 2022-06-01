namespace HotelBooking.Database.Entities;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<HotelReview> HotelReviews { get; set; }
}
