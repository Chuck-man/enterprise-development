using AirCompany.Domain;

namespace AirComany.API.DTO;

public class FlightPostDto
{
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
    public required int PlaneTypeId { get; set; }

    /// <summary>
    /// Список пассажиров, зарегистрированных на рейс
    /// </summary>
    public required List<RegisteredPassenger> Passengers { get; set; }
}
