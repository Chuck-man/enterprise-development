using AirCompany.Domain;

namespace AirComany.API.DTO;

public class RegisteredPassengerPostDto
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
    /// Рейс, на котором зарегистрирован пассажир
    /// </summary>
    public required int FlightId { get; set; }

    /// <summary>
    /// Пассажир, зарегистрированный на рейс
    /// </summary>
    public required int PassengerId { get; set; }
}
