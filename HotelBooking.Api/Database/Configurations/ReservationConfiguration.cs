using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Api.Database.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.StartDate)
            .IsRequired();
        builder
            .Property(a => a.EndDate)
            .IsRequired();
        builder
            .HasOne(a => a.User)
            .WithMany(b => b.Reservations)
            .HasForeignKey(c => c.UserId);
        builder
            .HasOne(a => a.Room)
            .WithMany(b => b.Reservations)
            .HasForeignKey(c => c.RoomId);
        builder.ToTable("Reservations");
    }
}
