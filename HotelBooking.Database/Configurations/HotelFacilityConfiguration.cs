using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Database.Configurations;

public class HotelFacilityConfiguration : IEntityTypeConfiguration<HotelFacilityEntity>
{
    public void Configure(EntityTypeBuilder<HotelFacilityEntity> builder)
    {
        builder
            .HasKey(a => new { a.HotelId, a.FacilityId });
        builder
            .HasOne(a => a.Hotel)
            .WithMany(b => b.Facilities)
            .HasForeignKey(c => c.HotelId);
        builder
            .HasOne(a => a.Facility)
            .WithMany(b => b.Facilities)
            .HasForeignKey(c => c.FacilityId);
        builder.ToTable("HotelFacilities");
    }
}
