namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий информация о зарегистрированном пассажире на рейсе для передачи данных.
/// </summary>
public class RegisteredPassengerDTO
{
    /// <summary>
    /// Номер зарегистрированного пассажира
    /// </summary>
    public required string Number { get; set; }

    /// <summary>
    /// Номер сиденья зарегистрированного пассажира
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа зарегистрированного пассажира
    /// </summary>
    public required double BaggageWeight { get; set; }

    /// <summary>
    /// Идентификатор рейса, на который зарегистрирован пассажир.
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Идентификатор пассажира, зарегистрированного на рейс.
    /// </summary>
    public required int PassengerId { get; set; }
}
