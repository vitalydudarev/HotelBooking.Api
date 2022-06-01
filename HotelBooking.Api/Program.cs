using HotelBooking.Api;
using HotelBooking.Api.Database;
using HotelBooking.Api.Middlewares;
using HotelBooking.Api.Repositories;
using HotelBooking.Api.Services;
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

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var value = configuration.GetValue<string>("Cache:CacheType");

builder.Services.AddSingleton<IHotelCache>(serviceProvider  =>
{
    switch (value)
    {
        case "Memory":
            return new HotelCache();
        default:
            throw new NotSupportedException("Cache type is not specified or unsupported.");
    }
});

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


