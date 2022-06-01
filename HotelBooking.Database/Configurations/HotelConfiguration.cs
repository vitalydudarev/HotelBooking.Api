using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Database.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Name)
            .IsRequired();
        builder
            .Property(a => a.Description)
            .IsRequired();
        builder
            .Property(a => a.Address)
            .IsRequired();
        builder.ToTable("Hotels");
    }
}
