using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Api.Database.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Capacity)
            .IsRequired();
        builder
            .Property(a => a.Description)
            .IsRequired();
        builder
            .Property(a => a.SmokingAllowed)
            .IsRequired();
        builder.ToTable("RoomTypes");
    }
}
