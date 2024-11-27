using AirCompany.Domain;
using AirComany.API.DTO;
using AutoMapper;

namespace AirComany.API;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Aircraft, AircraftPostDto>();
        CreateMap<Flight, AircraftPostDto>();
        CreateMap<Passenger, PassengerPostDto>();
        CreateMap<RegisteredPassenger, RegisteredPassengerPostDto>();

        CreateMap<AircraftGetDto, Aircraft>().ReverseMap();
        CreateMap<AircraftGetDto, Flight>().ReverseMap();
        CreateMap<PassengerGetDto, Passenger>().ReverseMap();
        CreateMap<RegisteredPassengerGetDto, RegisteredPassenger>().ReverseMap();
    }
}
