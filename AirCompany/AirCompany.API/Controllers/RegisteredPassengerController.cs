using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления зарегистрированными пассажирами 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RegisteredPassengerController(IRepository<RegisteredPassenger> registeredPassengerRepository,
    IRepository<Flight> flightRepository, IRepository<Passenger> passengerRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех зарегистрированных пассажиров
    /// </summary>
    /// <returns>Список зарегистрированных пассажиров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<RegisteredPassengerFullDto>> Get()
    {
        return Ok(registeredPassengerRepository.GetAll().Select(mapper.Map<RegisteredPassengerFullDto>));
    }

    /// <summary>
    /// Возвращает зарегистрированного пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <returns>Зарегистрированный пассажир или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<RegisteredPassengerFullDto> GetById(int id)
    {
        var registeredPassenger = registeredPassengerRepository.GetById(id);
        if (registeredPassenger == null) return NotFound();

        var registeredPassengerFullDto = mapper.Map<RegisteredPassengerFullDto>(registeredPassenger);

        return Ok(registeredPassengerFullDto);
    }

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира 
    /// </summary>
    /// <param name="entity">Информация о новом зарегистрированном пассажире</param>
    /// <returns>Добавленный зарегистрированный пассажир или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<RegisteredPassengerFullDto> Post([FromBody] RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);

        var flight = flightRepository.GetById(entity.FlightId);
        var existingPassenger = passengerRepository.GetById(entity.PassengerId);

        if (flight == null)
        {
            return BadRequest("Рейс не найден");
        }

        if (existingPassenger == null)
        {
            return BadRequest("Пассажир не найден");
        }

        registeredPassenger.Flight = flight;
        registeredPassenger.Passenger = existingPassenger;
       
        flight.Passengers = [];

        registeredPassengerRepository.Post(registeredPassenger);
        flightRepository.Put(flight.Id, flight);

        return CreatedAtAction(nameof(GetById), new { id = registeredPassenger.Id }, mapper.Map<RegisteredPassengerFullDto>(registeredPassenger));
    }

    /// <summary>
    /// Обновляет зарегистрированного пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <param name="entity">Обновлённая информация о зарегистрированном пассажире</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        var flight = flightRepository.GetById(entity.FlightId);
        var passenger = passengerRepository.GetById(entity.PassengerId);

        registeredPassenger.Passenger = passenger!;
        registeredPassenger.Flight = flight;
        return Ok(registeredPassengerRepository.Put(id, registeredPassenger));
    }

    /// <summary>
    /// Удаляет зарегистрированного пассажира по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(registeredPassengerRepository.Delete(id));
    }
}
