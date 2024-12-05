namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий полную информацию о рейсе для передачи данных.
/// </summary>
public class FlightFullDto
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
    /// Дата и время отправления рейса
    /// </summary>
    public required DateTime DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса
    /// </summary>
    public required DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Тип самолёта, совершающего рейс
    /// </summary>
    public required AircraftFullDto PlaneType { get; set; }

    /// <summary>
    /// Список идентификаторов зарегистрированных на рейс пассажиров.
    /// </summary>
    public List<RegisteredPassengerFullDto>? Passengers { get; set; }
}
