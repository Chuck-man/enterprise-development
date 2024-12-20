namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Passenger.
/// Реализует интерфейс IRepository для управления коллекцией пассажиров.
/// </summary>
public class PassengerRepository(AirCompanyContext context) : IRepository<Passenger>
{
    /// <summary>
    /// Удаляет пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира, который нужно удалить.</param>
    /// <returns>Возвращает true, если пассажир был успешно удален; иначе false.</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);

        if (value == null)
            return false;

        context.Passengers.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Получает всех пассажиров.
    /// </summary>
    /// <returns>Возвращает перечисление всех пассажиров.</returns>
    public IEnumerable<Passenger> GetAll() => context.Passengers.ToList();

    /// <summary>
    /// Получает пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Возвращает пассажира с заданным идентификатором или null, если не найден.</returns>
    public Passenger? GetById(int id) => context.Passengers.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Добавляет нового пассажира в репозиторий.
    /// </summary>
    /// <param name="entity">Новый пассажир, который нужно добавить.</param>
    /// <returns>Возвращает добавленного пассажира.</returns>
    public Passenger Post(Passenger entity)
    {
        context.Passengers.Add(entity);
        context.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о пассажире по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира, который нужно обновить.</param>
    /// <param name="entity">Объект пассажира с новыми данными.</param>
    /// <returns>Возвращает true, если пассажир был успешно обновлен; иначе false.</returns>
    public bool Put(int id, Passenger entity)
    {
        var oldValue = GetById(id);

        if (oldValue == null)
            return false;

        oldValue.PassportNumber = entity.PassportNumber;
        oldValue.FullName = entity.FullName;

        context.SaveChanges();
        return true;
    }
}
