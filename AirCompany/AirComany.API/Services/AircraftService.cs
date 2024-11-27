using AutoMapper;
using AirComany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Repositories;
using System.Security.Cryptography;

namespace AirCompany.API.Services;

public class AircraftService(IRepository<Aircraft> aircraftRepository, IMapper mapper) : IService<AircraftPostDto, AircraftGetDto>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return aircraftRepository.Delete(id);
    }

    public IEnumerable<AircraftGetDto> GetAll()
    {
        return aircraftRepository.GetAll().Select(mapper.Map<AircraftGetDto>);
    }

    public AircraftGetDto? GetById(int id)
    {
        var aircraft = aircraftRepository.GetById(id);
        return mapper.Map<AircraftGetDto>(aircraft);
    }

    public AircraftGetDto? Post(AircraftPostDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        aircraft.Id = _id++;
        return mapper.Map<AircraftGetDto>(aircraftRepository.Post(aircraft));
    }

    public bool Put(int id, AircraftPostDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        return aircraftRepository.Put(id, aircraft);
    }
}