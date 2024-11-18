namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о зарегистрированном пассажире
/// </summary>
/// <param name="id">Идентификатор зарегистрированного пассажира</param>
/// <param name="number">Номер зарегистрированного пассажира</param>
/// <param name="seatNumber">Номер сиденья зарегистрированного пассажира</param>
/// <param name="baggageWeight">Вес багажа зарегистрированного пассажира</param>
/// <param name="flight">Рейс, на котором зарегистрирован пассажир</param>
/// <param name="passenger">Пассажир, зарегистрированный на рейс</param>
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
    /// Идентификатор зарегистрированного пассажира
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер зарегистрированного пассажира
    /// </summary>
    public string? Number { get; set; } = number;

    /// <summary>
    /// Номер сиденья зарегистрированного пассажира
    /// </summary>
    public string? SeatNumber { get; set; } = seatNumber;

    /// <summary>
    /// Вес багажа зарегистрированного пассажира
    /// </summary>
    public double? BaggageWeight { get; set; } = baggageWeight;

    /// <summary>
    /// Рейс, на котором зарегистрирован пассажир
    /// </summary>
    public Flight? Flight { get; set; } = flight;

    /// <summary>
    /// Пассажир, зарегистрированный на рейс
    /// </summary>
    public Passenger? Passenger { get; set; } = passenger;
}

