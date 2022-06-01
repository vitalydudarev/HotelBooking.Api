using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Database.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<FacilityEntity>
{
    public void Configure(EntityTypeBuilder<FacilityEntity> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Title)
            .IsRequired();
        builder
            .Property(a => a.Description);
        builder
            .Property(a => a.Icon);;
        builder.ToTable("Facilities");
    }
}
