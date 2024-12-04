using AirCompany.API;
using AirCompany.Domain.Repositories;
using AirCompany.Domain;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<IRepository<Aircraft>, AircraftRepository>();
builder.Services.AddSingleton<IRepository<Flight>, FlightRepository>();
builder.Services.AddSingleton<IRepository<Passenger>, PassengerRepository>();
builder.Services.AddSingleton<IRepository<RegisteredPassenger>, RegisteredPassengerRepository>();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddControllers();

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
