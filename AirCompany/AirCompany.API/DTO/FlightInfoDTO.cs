namespace AirCompany.API.DTO;

/// <summary>
/// DTO для информации о рейсе
/// </summary>
public class FlightInfoDTO
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
    /// Дата и время отправления
    /// </summary>
    public required DateTime DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса
    /// </summary>
    public required DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Количество пассажиров
    /// </summary>
    public required int PassengersCount { get; set; }
}
