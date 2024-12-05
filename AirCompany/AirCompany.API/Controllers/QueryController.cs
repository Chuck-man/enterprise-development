using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для запросов к данным о авиарейсах и пассажирах
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueryController(IRepository<Flight> flightsRepository,
    IRepository<RegisteredPassenger> registeredPassengerRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех авиарейсов, вылетевших из указанного пункта отправления в указанный пункт прибытия
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <param name="arrival">Пункт прибытия</param>
    /// <returns>Список авиарейсов</returns>
    [HttpGet("flights")]
    public ActionResult<List<FlightFullDto>> GetFlightsByDepartureAndArrival(string departure, string arrival)
    {
        var flights = flightsRepository.GetAll()
            .Where(f => f.DeparturePoint == departure && f.ArrivalPoint == arrival)
            .ToList();
        return Ok(mapper.Map<List<FlightFullDto>>(flights));
    }

    /// <summary>
    /// Возвращает список пассажиров, летящих данным рейсом, вес багажа которых равен нулю
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список пассажиров</returns>
    [HttpGet("passengers/no-baggage")]
    public ActionResult<List<RegisteredPassengerDto>> GetPassengersWithNoBaggage(int flightId)
    {
        var passengers = registeredPassengerRepository.GetAll()
            .Where(rp => rp.Flight != null && rp.Flight.Id == flightId && rp.BaggageWeight == 0)
            .OrderBy(rp => rp.Passenger.FullName)
            .Select(rp => new RegisteredPassengerDto
            {
                Number = rp.Number,
                SeatNumber = rp.SeatNumber,
                BaggageWeight = rp.BaggageWeight,
                FlightId = rp.Flight!.Id,
                PassengerId = rp.Passenger!.Id
            })
            .ToList();

        return Ok(passengers);
    }

    /// <summary>
    /// Возвращает сводную информацию обо всех полетах самолетов данного типа в указанный период времени
    /// </summary>
    /// <param name="aircraftTypeId">Тип самолета</param>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список полетов</returns>
    [HttpGet("flights-summary")]
    public ActionResult<List<FlightInfoDto>> GetFlightSummaryByAircraftType(int aircraftTypeId, DateTime startDate, DateTime endDate)
    {
        var flightSummary = flightsRepository.GetAll()
            .Where(f => f.PlaneType.Id == aircraftTypeId && f.DepartureDate >= startDate &&
                        f.DepartureDate <= endDate)
            .Select(f => new FlightInfoDto
            {
                FlightId = f.Id,
                DeparturePoint = f.DeparturePoint,
                ArrivalPoint = f.ArrivalPoint,
                DepartureDate = f.DepartureDate,
                ArrivalDate = f.ArrivalDate,
                PassengersCount = registeredPassengerRepository
                    .GetAll()
                    .Count(rp => rp.Flight?.Id == f.Id)
            })
            .ToList();

        return Ok(flightSummary);
    }

    /// <summary>
    /// Возвращает топ 5 авиарейсов по количеству перевезённых пассажиров
    /// </summary>
    /// <returns>Топ 5 авиарейсов</returns>
    [HttpGet("top-flights")]
    public ActionResult<List<TopFlightsDto>> GetTopFlightsByPassengerCount()
    {
        var topFlights = flightsRepository.GetAll()
            .Select(f => new TopFlightsDto
            {
                FlightId = f.Id,
                DeparturePoint = f.DeparturePoint,
                ArrivalPoint = f.ArrivalPoint,
                PassengersCount = registeredPassengerRepository
                    .GetAll()
                    .Count(rp => rp.Flight?.Id == f.Id)
            })
            .OrderByDescending(f => f.PassengersCount)
            .Take(5)
            .ToList();

        return Ok(topFlights);
    }

    /// <summary>
    /// Возвращает список рейсов с минимальным временем в пути
    /// </summary>
    /// <returns>Список рейсов с минимальным временем в пути</returns>
    [HttpGet("flights/min-duration")]
    public ActionResult<List<FlightFullDto>> GetFlightsWithMinimumDuration()
    {
        var minDuration = flightsRepository.GetAll()
            .Min(f => f.ArrivalDate - f.DepartureDate);

        var flights = flightsRepository.GetAll()
            .Where(f => (f.ArrivalDate - f.DepartureDate) == minDuration)
        .ToList();

        return Ok(mapper.Map<List<FlightFullDto>>(flights));
    }

    /// <summary>
    /// Возвращает информацию о средней и максимальной загрузке авиарейсов из заданного пункта отправления
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <returns>Средняя и максимальная загрузка</returns>
    [HttpGet("load-info")]
    public ActionResult<OccupancyInfoDto> GetLoadInfoByDeparture(string departure)
    {
        var flights = flightsRepository.GetAll()
            .Where(f => f.DeparturePoint == departure)
            .ToList();

        var averageLoad = flights.Average(f => registeredPassengerRepository.GetAll().Count(rp => rp.Flight?.Id == f.Id));
        var maxLoad = flights.Max(f => registeredPassengerRepository.GetAll().Count(rp => rp.Flight?.Id == f.Id));

        return Ok(new OccupancyInfoDto
        {
            AverageLoad = averageLoad,
            MaxLoad = maxLoad
        });
    }
}
