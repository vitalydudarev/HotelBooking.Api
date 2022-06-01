using HotelBooking.Api.Middlewares;
using HotelBooking.Database;
using HotelBooking.Database.Repositories;
using HotelBooking.Domain.Repositories;
using HotelBooking.Domain.Services;
using HotelBooking.Services;
using HotelBooking.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(opt =>
    opt.UseNpgsql(configuration.GetConnectionString("DatabaseContext")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var value = configuration.GetValue<string>("Cache:CacheType");

CacheFactory.AddCacheService(value, builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


