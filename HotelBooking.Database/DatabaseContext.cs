using HotelBooking.Database.Configurations;
using HotelBooking.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<HotelFacility> HotelFacilities { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

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
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration == null || optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseNpgsql(_configuration["ConnectionString"]);
    }
}
