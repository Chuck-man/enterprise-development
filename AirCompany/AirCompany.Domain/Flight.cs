namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о рейсе
/// </summary>
/// <param name="id">Идентифиактор рейса</param>
/// <param name="number">Номер рейса</param>
/// <param name="departurePoint">Пункт отправления рейса</param>
/// <param name="arrivalPoint">Пункт прибытия рейса</param>
/// <param name="departureDate">Время отправления рейса</param>
/// <param name="arrivalDate">Время прибытия рейса</param>
/// <param name="planeType">Тип самолёта, совершающего рейс</param>
/// <param name="passengers">Список пассажиров, зарегестрированных на рейс</param>
public class Flight
    (
    int id,
    string? number,
    string? departurePoint,
    string? arrivalPoint,
    DateTime? departureDate,
    DateTime? arrivalDate,
    Aircraft? planeType,
    List<Passenger>? passengers
    )
{
    /// <summary>
    /// Идентифиактор рейса
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер рейса
    /// </summary>
    public string? Number { get; set; } = number;

    /// <summary>
    /// Пункт отправления рейса
    /// </summary>
    public string? DeparturePoint { get; set; } = departurePoint;

    /// <summary>
    /// Пункт прибытия рейса
    /// </summary>
    public string? ArrivalPoint { get; set; } = arrivalPoint;

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public DateTime? DepartureDate { get; set; } = departureDate;

    /// <summary>
    /// Время прибытия рейса
    /// </summary>
    public DateTime? ArrivalDate { get; set; } = arrivalDate;

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public TimeOnly? DepartureTime => DepartureDate.HasValue ? TimeOnly.FromDateTime(DepartureDate.Value) : null;

    /// <summary>
    /// Время полёта
    /// </summary>
    public TimeSpan? TravelTime => (DepartureDate.HasValue && ArrivalDate.HasValue) ? DepartureDate.Value - ArrivalDate.Value : null;

    /// <summary>
    /// Тип самолёта, совершающего рейс
    /// </summary>
    public Aircraft? PlaneType { get; set; } = planeType;

    /// <summary>
    /// Список пассажиров, зарегестрированных на рейс
    /// </summary>
    public List<Passenger>? Passengers { get; set; } = passengers;
}

