using AirCompany.API.DTO;
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
public class PassengerController(IRepository<Passenger> repository, IMapper mapper) : Controller
{
    /// <summary>
    /// Возвращает список всех пассажиров.
    /// </summary>
    /// <returns>Перечисление всех пассажиров.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PassengerFullDto>> GetAll()
    {
        return Ok(repository.GetAll().Select(mapper.Map<PassengerFullDto>));
    }

    /// <summary>
    /// Возвращает full-dto пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Full-dto пассажира с указанным идентификатором или null, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<PassengerFullDto>? GetById(int id)
    {
        var passenger = repository.GetById(id);
        return mapper.Map<PassengerFullDto>(passenger);
    }

    /// <summary>
    /// Добавляет нового пассажира.
    /// </summary>
    /// <param name="entity">DTO объекта пассажира для добавления.</param>
    /// <returns>Full-dto добавленного пассажира или null, если добавление не удалось.</returns>
    [HttpPost]
    public ActionResult<PassengerFullDto>? Post(PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        return mapper.Map<PassengerFullDto>(repository.Post(passenger));
    }

    /// <summary>
    /// Обновляет данные о пассажире по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для обновления.</param>
    /// <param name="entity">DTO объекта пассажира с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        return Ok(repository.Put(id, passenger));
    }

    /// <summary>
    /// Удаляет пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return Ok(repository.Delete(id));
    }
}
