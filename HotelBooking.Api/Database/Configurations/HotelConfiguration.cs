using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Api.Database.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<HotelEntity>
{
    public void Configure(EntityTypeBuilder<HotelEntity> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Name)
            .IsRequired();
        builder
            .Property(a => a.Address)
            .IsRequired();
        builder.ToTable("Hotels");
    }
}
