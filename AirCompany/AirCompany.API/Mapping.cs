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
        CreateMap<Aircraft, AircraftFullDTO>().ReverseMap();
        CreateMap<Flight, FlightFullDTO>()
            .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.Passengers.Select(p => new RegisteredPassengerFullDTO
            {
                Id = p.Id,
                Number = p.Number,
                SeatNumber = p.SeatNumber,
                BaggageWeight = p.BaggageWeight,
                FlightId = p.Flight!.Id,
                Passenger = p.Passenger == null ? null : new PassengerFullDTO { Id = p.Passenger.Id, FullName = p.Passenger.FullName, PassportNumber = p.Passenger.PassportNumber } 
            }).ToList()));

        CreateMap<Passenger, PassengerFullDTO>().ReverseMap();
        CreateMap<RegisteredPassenger, RegisteredPassengerFullDTO>().ReverseMap();
        CreateMap<AircraftDTO, Aircraft>().ReverseMap();
        CreateMap<FlightDTO, Flight>().ReverseMap();
        CreateMap<PassengerDTO, Passenger>().ReverseMap();
        CreateMap<RegisteredPassengerDTO, RegisteredPassenger>().ReverseMap();
    }
}
