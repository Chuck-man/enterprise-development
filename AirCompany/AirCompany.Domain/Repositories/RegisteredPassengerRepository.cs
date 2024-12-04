namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями RegisteredPassenger.
/// Реализует интерфейс IRepository для управления коллекцией зарегистрированных пассажиров.
/// </summary>
public class RegisteredPassengerRepository : IRepository<RegisteredPassenger>
{
    private readonly List<RegisteredPassenger> _registeredPassengers = [];
    private int _id = 1;

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

        _registeredPassengers.Remove(value);
        return true;
    }

    /// <summary>
    /// Получает всех зарегистрированных пассажиров.
    /// </summary>
    /// <returns>Возвращает перечисление всех зарегистрированных пассажиров.</returns>
    public IEnumerable<RegisteredPassenger> GetAll() => _registeredPassengers;

    /// <summary>
    /// Получает зарегистрированного пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира.</param>
    /// <returns>Возвращает зарегистрированного пассажира с заданным идентификатором или null, если не найден.</returns>
    public RegisteredPassenger? GetById(int id) => _registeredPassengers.Find(r => r.Id == id);

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира в репозиторий.
    /// </summary>
    /// <param name="entity">Новый зарегистрированный пассажир, которого нужно добавить.</param>
    /// <returns>Возвращает добавленного зарегистрированного пассажира.</returns>
    public RegisteredPassenger? Post(RegisteredPassenger entity)
    {
        entity.Id = _id++;
        _registeredPassengers.Add(entity);
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

        oldValue.Number = entity.Number;
        oldValue.SeatNumber = entity.SeatNumber;
        oldValue.BaggageWeight = entity.BaggageWeight;
        oldValue.Flight = entity.Flight;
        oldValue.Passenger = entity.Passenger;
        return true;
    }
}
