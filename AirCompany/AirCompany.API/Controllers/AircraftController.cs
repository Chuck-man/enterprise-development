using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления самолетами 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AircraftController(IRepository<Aircraft> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех самолетов.
    /// </summary>
    /// <returns>Перечисление всех самолетов.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<AircraftFullDTO>> GetAll()
    {
        return Ok(repository.GetAll().Select(mapper.Map<AircraftFullDTO>));
    }

    /// <summary>
    /// Возвращает full-dto самолета по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета.</param>
    /// <returns> Full-dto самолета с указанным идентификатором или null, если не найден.</returns>
    [HttpGet("{id}")]
    public ActionResult<AircraftFullDTO> GetById(int id)
    {
        var aircraft = repository.GetById(id);
        return mapper.Map<AircraftFullDTO>(aircraft);
    }

    /// <summary>
    /// Добавляет новый самолет.
    /// </summary>
    /// <param name="entity">DTO объекта самолета для добавления.</param>
    /// <returns> Full-dto добавленного самолета или null, если добавление не удалось.</returns>
    [HttpPost]
    public ActionResult<AircraftFullDTO> Post([FromBody] AircraftDTO entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        return mapper.Map<AircraftFullDTO>(repository.Post(aircraft));
    }

    /// <summary>
    /// Обновляет данные о самолете по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета для обновления.</param>
    /// <param name="entity">DTO объекта самолета с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] AircraftDTO entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        return Ok(repository.Put(id, aircraft));
    }

    /// <summary>
    /// Удаляет самолет по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return Ok(repository.Delete(id));
    }
}
