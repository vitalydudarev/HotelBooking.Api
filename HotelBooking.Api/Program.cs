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

builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();

builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IReservationService, ReservationService>();

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
