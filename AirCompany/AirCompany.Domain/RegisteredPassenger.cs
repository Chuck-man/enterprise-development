namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о зарегестрированном пассажире
/// </summary>
/// <param name="id">Идентификатор зарегестрированного пассажира</param>
/// <param name="number">Номер зарегестрированного пассажира</param>
/// <param name="seatNumber">Номер сиденья зарегестрированного пассажира</param>
/// <param name="baggageWeight">Вес багажа зарегестрированного пассажира</param>
/// <param name="flight">Рейс, на котором зарегестрирован пассажир</param>
/// <param name="passenger">Пассажир, зарегестрированный на рейс</param>
public class RegisteredPassenger
    (
    int id,
    string? number,
    string? seatNumber,
    double? baggageWeight,
    Flight? flight,
    Passenger? passenger
    )
{
    /// <summary>
    /// Идентификатор зарегестрированного пассажира
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер зарегестрированного пассажира
    /// </summary>
    public string? Number { get; set; } = number;

    /// <summary>
    /// Номер сиденья зарегестрированного пассажира
    /// </summary>
    public string? SeatNumber { get; set; } = seatNumber;

    /// <summary>
    /// Вес багажа зарегестрированного пассажира
    /// </summary>
    public double? BaggageWeight { get; set; } = baggageWeight;

    /// <summary>
    /// Рейс, на котором зарегестрирован пассажир
    /// </summary>
    public Flight? Flight { get; set; } = flight;

    /// <summary>
    /// Пассажир, зарегестрированный на рейс
    /// </summary>
    public Passenger? Passenger { get; set; } = passenger;
}

