using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями RegisteredPassenger.
/// Реализует интерфейс IRepository для управления коллекцией зарегистрированных пассажиров.
/// </summary>
public class RegisteredPassengerRepository(AirCompanyContext context,
    IRepository<Flight> flightRepository, IRepository<Passenger> passengerRepository) : IRepository<RegisteredPassenger>
{
    /// <summary>
    /// Удаляет зарегистрированного пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира, которого нужно удалить.</param>
    /// <returns>Возвращает true, если пассажир был успешно удален; иначе false.</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);

        if (value == null)
            return false;

        context.RegisteredPassengers.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Получает всех зарегистрированных пассажиров.
    /// </summary>
    /// <returns>Возвращает перечисление всех зарегистрированных пассажиров.</returns>
    public IEnumerable<RegisteredPassenger> GetAll() => context.RegisteredPassengers
        .Include(rp => rp.Passenger)
        .ToList();

    /// <summary>
    /// Получает зарегистрированного пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира.</param>
    /// <returns>Возвращает зарегистрированного пассажира с заданным идентификатором или null, если не найден.</returns>
    public RegisteredPassenger? GetById(int id) => context.RegisteredPassengers
        .Include(rp => rp.Passenger)
        .FirstOrDefault(rp => rp.Id == id);

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира в репозиторий.
    /// </summary>
    /// <param name="entity">Новый зарегистрированный пассажир, которого нужно добавить.</param>
    /// <returns>Возвращает добавленного зарегистрированного пассажира.</returns>
    public RegisteredPassenger Post(RegisteredPassenger entity)
    {
        var flight = context.Flights.Find(entity.FlightId);
        var passenger = context.Passengers.Find(entity.PassengerId);

        entity.Flight = flight;  
        entity.Passenger = passenger!;

        context.RegisteredPassengers.Add(entity);
        context.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о зарегистрированном пассажире по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира, которого нужно обновить.</param>
    /// <param name="entity">Объект зарегистрированного пассажира с новыми данными.</param>
    /// <returns>Возвращает true, если пассажир был успешно обновлен; иначе false.</returns>
    public bool Put(int id, RegisteredPassenger entity)
    {
        var oldValue = GetById(id);

        if (oldValue == null)
            return false;

        var flight = flightRepository.GetById(entity.FlightId);
        var passenger = passengerRepository.GetById(entity.PassengerId);

        if (flight == null || passenger == null)
            return false;

        oldValue.Number = entity.Number;
        oldValue.SeatNumber = entity.SeatNumber;
        oldValue.BaggageWeight = entity.BaggageWeight;
        oldValue.Flight = entity.Flight;
        oldValue.Passenger = entity.Passenger;

        context.SaveChanges();
        return true;
    }
}
