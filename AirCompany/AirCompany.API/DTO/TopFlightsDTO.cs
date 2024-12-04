namespace AirCompany.API.DTO;

/// <summary>
/// DTO для топ рейсов
/// </summary>
public class TopFlightsDTO
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Количество перевезённых пассажиров
    /// </summary>
    public required int PassengersCount { get; set; }
}
