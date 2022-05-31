using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Api.Database.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Title)
            .IsRequired();
        builder
            .Property(a => a.RoomNumber)
            .IsRequired();
        builder
            .HasOne(a => a.RoomType)
            .WithMany(b => b.Rooms)
            .HasForeignKey(c => c.RoomTypeId);
        builder
            .HasOne(a => a.Hotel)
            .WithMany(b => b.Rooms)
            .HasForeignKey(c => c.HotelId);
        builder.ToTable("Rooms");
    }
}
