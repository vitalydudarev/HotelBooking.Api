using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Database.Configurations;

public class HotelReviewConfiguration : IEntityTypeConfiguration<HotelReview>
{
    public void Configure(EntityTypeBuilder<HotelReview> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Rate)
            .IsRequired();
        builder
            .Property(a => a.Comment);
        builder
            .HasOne(a => a.User)
            .WithMany(b => b.HotelReviews)
            .HasForeignKey(c => c.UserId);
        builder
            .HasOne(a => a.Hotel)
            .WithMany(b => b.Reviews)
            .HasForeignKey(c => c.HotelId);
        builder.ToTable("HotelReviews");
    }
}
