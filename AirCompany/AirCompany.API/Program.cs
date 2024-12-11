using AirCompany.API;
using AirCompany.Domain.Repositories;
using AirCompany.Domain;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IRepository<Aircraft>, AircraftRepository>();
builder.Services.AddScoped<IRepository<Flight>, FlightRepository>();
builder.Services.AddScoped<IRepository<Passenger>, PassengerRepository>();
builder.Services.AddScoped<IRepository<RegisteredPassenger>, RegisteredPassengerRepository>();

builder.Services.AddDbContext<AirCompanyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
