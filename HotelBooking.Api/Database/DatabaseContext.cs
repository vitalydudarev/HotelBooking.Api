using HotelBooking.Api.Database.Configurations;
using HotelBooking.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Api.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<HotelEntity> Hotels { get; set; }
    public DbSet<FacilityEntity> Facilities { get; set; }
    public DbSet<HotelFacilityEntity> HotelFacilities { get; set; }

    public DatabaseContext(IConfiguration configuration, DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new FacilityConfiguration());
        modelBuilder.ApplyConfiguration(new HotelFacilityConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration == null || optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseNpgsql(_configuration["ConnectionString"]);
    }
}
