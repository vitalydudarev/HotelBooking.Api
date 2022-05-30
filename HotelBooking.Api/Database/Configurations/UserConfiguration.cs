using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Api.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Email)
            .IsRequired();
        builder
            .Property(a => a.Name);
        builder
            .Property(a => a.Surname);;
        builder.ToTable("Users");
    }
}
