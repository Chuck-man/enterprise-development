using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Flight.
/// Реализует интерфейс IRepository для управления коллекцией рейсов.
/// </summary>
public class FlightRepository(AirCompanyContext context, IRepository<Aircraft> aircraftRepository) : IRepository<Flight>
{
    /// <summary>
    /// Удаляет рейс по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса, который нужно удалить.</param>
    /// <returns>Возвращает true, если рейс был успешно удален; иначе false.</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);

        if (value == null)
            return false;

        context.Flights.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Получает все рейсы.
    /// </summary>
    /// <returns>Возвращает перечисление всех рейсов.</returns>
    public IEnumerable<Flight> GetAll() => context.Flights
        .Include(f => f.PlaneType)
        .ToList();

    /// <summary>
    /// Получает рейс по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса.</param>
    /// <returns>Возвращает рейс с заданным идентификатором или null, если не найден.</returns>
    public Flight? GetById(int id) => context.Flights
        .Include(f => f.PlaneType)
        .FirstOrDefault(f => f.Id == id);

    /// <summary>
    /// Добавляет новый рейс в репозиторий.
    /// </summary>
    /// <param name="entity">Новый рейс, который нужно добавить.</param>
    /// <returns>Возвращает добавленный рейс.</returns>
    public Flight Post(Flight entity)
    {
        var aircraft = aircraftRepository.GetById(entity.PlaneTypeId);
        if (aircraft == null)
            throw new ArgumentException("Самолет не найден.");

        entity.PlaneType = aircraft;

        context.Flights.Add(entity);
        context.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о рейсе по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса, который нужно обновить.</param>
    /// <param name="entity">Объект рейса с новыми данными.</param>
    /// <returns>Возвращает true, если рейс был успешно обновлен; иначе false.</returns>
    public bool Put(int id, Flight entity)
    {
        var oldValue = GetById(id);

        if (oldValue == null)
            return false;

        var aircraft = aircraftRepository.GetById(entity.PlaneTypeId);
        if (aircraft == null)
            return false;

        oldValue.Number = entity.Number;
        oldValue.DeparturePoint = entity.DeparturePoint;
        oldValue.ArrivalPoint = entity.ArrivalPoint;
        oldValue.DepartureDate = entity.DepartureDate;
        oldValue.ArrivalDate = entity.ArrivalDate;
        oldValue.PlaneType = aircraft;

        context.SaveChanges();
        return true;
    }
}
