namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий информацию о рейсе для передачи данных.
/// </summary>
public class FlightDTO
{
    /// <summary>
    /// Номер рейса.
    /// </summary>
    public required string? Number { get; set; }

    /// <summary>
    /// Место отправления рейса.
    /// </summary>
    public required string? DeparturePoint { get; set; }

    /// <summary>
    /// Место назначения рейса.
    /// </summary>
    public required string? ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления рейса.
    /// </summary>
    public required DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса.
    /// </summary>
    public required DateTime? ArrivalDate { get; set; }

    /// <summary>
    /// Идентификатор типа самолета, используемого для рейса.
    /// </summary>
    public required int PlaneTypeId { get; set; }
}
