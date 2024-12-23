﻿using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления рейсами 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IRepository<Flight> flightRepository, IRepository<Aircraft> aircraftRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех рейсов
    /// </summary>
    /// <returns>Список рейсов</returns>
    [HttpGet]
    public ActionResult<IEnumerable<FlightFullDto>> GetAll()
    {
        return Ok(flightRepository.GetAll().Select(mapper.Map<FlightFullDto>));
    }

    /// <summary>
    /// Возвращает рейс по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Рейс или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<FlightFullDto>? GetById(int id)
    {
        var flight = flightRepository.GetById(id);
        if (flight == null) return NotFound();


        var flightFullDto = mapper.Map<FlightFullDto>(flight);

        flightFullDto.Passengers = flight.Passengers.Select(p => mapper.Map<RegisteredPassengerFullDto>(p)).ToList();


        return Ok(flightFullDto);
    }

    /// <summary>
    /// Добавляет новый рейс 
    /// </summary>
    /// <param name="entity">Информация о новом рейсе</param>
    /// <returns>Добавленный рейс или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<FlightFullDto> Post([FromBody] FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        var aircraft = aircraftRepository.GetById(entity.PlaneTypeId);
        flight.PlaneType = aircraft!;
        return mapper.Map<FlightFullDto>(flightRepository.Post(flight));
    }

    /// <summary>
    /// Обновляет рейс по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <param name="entity">Обновлённая информация о рейсе</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        return Ok(flightRepository.Put(id, flight));
    }

    /// <summary>
    /// Удаляет рейс по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return Ok(flightRepository.Delete(id));
    }
}
