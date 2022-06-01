using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Email)
            .IsRequired();
        builder
            .Property(a => a.Name);
        builder
            .Property(a => a.Surname);
        builder.ToTable("Users");
    }
}
