namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о зарегистрированном пассажире
/// </summary>
public class RegisteredPassenger
{
    /// <summary>
    /// Идентификатор зарегистрированного пассажира
    /// </summary>
    public required int Id { get; set; }

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
    public required Flight? Flight { get; set; }

    /// <summary>
    /// Пассажир, зарегистрированный на рейс
    /// </summary>
    public required Passenger Passenger { get; set; }
}

