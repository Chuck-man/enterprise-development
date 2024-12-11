using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о пассажире
/// </summary>
[Table("passengers")]
public class Passenger
{
    /// <summary>
    /// Идентификатор пассажира
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    [Column("passport_number")]
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    [Column("full_name")]
    public required string FullName { get; set; }

    /// <summary>
    /// Список зарегистрированных пассажиров на рейсы.
    /// </summary>
    public List<RegisteredPassenger>? RegisteredPassengers { get; set; }
}

