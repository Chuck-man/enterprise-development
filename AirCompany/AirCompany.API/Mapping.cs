using AirCompany.API.DTO;
using AirCompany.Domain;
using AutoMapper;

namespace AirCompany.API;

/// <summary>
/// Класс для маппинга
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Маппинг сущностей
    /// </summary>
    public Mapping()
    {
        CreateMap<Aircraft, AircraftFullDto>().ReverseMap();
        CreateMap<Flight, FlightFullDto>()
            .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.Passengers.Select(p => new RegisteredPassengerFullDto
            {
                Id = p.Id,
                Number = p.Number,
                SeatNumber = p.SeatNumber,
                BaggageWeight = p.BaggageWeight,
                FlightId = p.Flight!.Id,
                Passenger = new PassengerFullDto { Id = p.Passenger.Id, FullName = p.Passenger.FullName, PassportNumber = p.Passenger.PassportNumber }
            }).ToList()));

        CreateMap<Passenger, PassengerFullDto>().ReverseMap();
        CreateMap<RegisteredPassenger, RegisteredPassengerFullDto>().ReverseMap();
        CreateMap<AircraftDto, Aircraft>().ReverseMap();
        CreateMap<FlightDto, Flight>().ReverseMap();
        CreateMap<PassengerDto, Passenger>().ReverseMap();
        CreateMap<RegisteredPassengerDto, RegisteredPassenger>().ReverseMap();
    }
}
