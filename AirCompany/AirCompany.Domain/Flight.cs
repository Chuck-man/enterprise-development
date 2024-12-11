using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о рейсе
/// </summary>
[Table("flights")]
public class Flight
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    [Column("number")]
    public required string Number { get; set; }

    /// <summary>
    /// Пункт отправления рейса
    /// </summary>
    [Column("departure_point")]
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия рейса
    /// </summary>
    [Column("arrival_point")]
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления рейса
    /// </summary>
    [Column("departure_date")]
    public required DateTime DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса
    /// </summary>
    [Column("arrival_date")]
    public required DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Время отправления рейса
    /// </summary>
    public TimeOnly DepartureTime => TimeOnly.FromDateTime(DepartureDate);

    /// <summary>
    /// Время полёта
    /// </summary>
    public TimeSpan TravelTime => ArrivalDate - DepartureDate;

    /// <summary>
    /// Тип самолёта, совершающего рейс
    /// </summary>
    public Aircraft? PlaneType { get; set; }

    /// <summary>
    /// Идентификатор типа самолета.
    /// </summary>
    [ForeignKey("aircraftType")]
    public int PlaneTypeId { get; set; } // Добавлено

    /// <summary>
    /// Список пассажиров, зарегистрированных на рейс
    /// </summary>
    [Column("id")]
    public required List<RegisteredPassenger> Passengers { get; set; }
}

