namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о рейсе
/// </summary>
public class Flight
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    public required string Number { get; set; }

    /// <summary>
    /// Пункт отправления рейса
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия рейса
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public required DateTime DepartureDate { get; set; }

    /// <summary>
    /// Время прибытия рейса
    /// </summary>
    public required DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public TimeOnly DepartureTime => TimeOnly.FromDateTime(DepartureDate);

    /// <summary>
    /// Время полёта
    /// </summary>
    public TimeSpan TravelTime => DepartureDate - ArrivalDate;

    /// <summary>
    /// Тип самолёта, совершающего рейс
    /// </summary>
    public required Aircraft PlaneType { get; set; }

    /// <summary>
    /// Список пассажиров, зарегистрированных на рейс
    /// </summary>
    public required List<RegisteredPassenger> Passengers { get; set; }
}

