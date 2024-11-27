using AutoMapper;
using AirCompany.Domain.Repositories;
using AirCompany.API.Services;
using AirCompany.Domain;
using AirComany.API.DTO;

namespace AirComany.API.Services;

public class FlightService(
    IRepository<Flight> flightRepository,
    IRepository<Aircraft> aircraftRepository,
    IRepository<RegisteredPassenger> registeredPassengerRepository,
    IMapper mapper) : IService<FlightGetDto, FlightPostDto>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return flightRepository.Delete(id);
    }

    public IEnumerable<FlightPostDto> GetAll()
    {
        return flightRepository.GetEntities().Select(mapper.Map<FlightPostDto>);
    }

    public FlightPostDto? GetById(int id)
    {
        var flight = flightRepository.GetId(id);
        if (flight == null) return null;
        var FlightPostDto = mapper.Map<FlightPostDto>(flight);
        var test = registeredPassengerRepository.GetEntities().ToList();
        FlightPostDto.Passengers = registeredPassengerRepository.GetEntities()
            .Where(p => p.Flight?.Id == flight.Id)
            .ToList()
            .Select(mapper.Map<RegisteredPassengerPostDto>)
            .ToList();
        if (flight.PlaneType != null) FlightPostDto.PlaneTypeId = flight.PlaneType.Id;
        return FlightPostDto;
    }

    public FlightPostDto? Post(FlightGetDto entity)
    {
        throw new NotImplementedException();
    }

    public bool Put(int id, FlightGetDto entity)
    {
        throw new NotImplementedException();
    }
}
