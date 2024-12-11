using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о зарегистрированном пассажире
/// </summary>
[Table("registered_passengers")]
public class RegisteredPassenger
{
    /// <summary>
    /// Идентификатор зарегистрированного пассажира
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер зарегистрированного пассажира
    /// </summary>
    [Column("number")]
    public required string Number { get; set; }

    /// <summary>
    /// Номер сиденья зарегистрированного пассажира
    /// </summary>
    [Column("seat_number")]
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа зарегистрированного пассажира
    /// </summary>
    [Column("baggage_weight")]
    public required double BaggageWeight { get; set; }

    /// <summary>
    /// Рейс, на котором зарегистрирован пассажир
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Пассажир, зарегистрированный на рейс
    /// </summary>
    public required Passenger Passenger { get; set; }

    /// <summary>
    /// Идентификатор рейса.
    /// </summary>
    [ForeignKey("flight")]
    public int FlightId { get; set; } // Добавлено

    /// <summary>
    /// Идентификатор пассажира.
    /// </summary>
    [ForeignKey("passenger")]
    public int PassengerId { get; set; } // Добавлено
}

