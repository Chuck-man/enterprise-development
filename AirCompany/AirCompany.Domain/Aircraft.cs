using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о самолёте
/// </summary>
[Table("aircraft")]
public class Aircraft
{
    /// <summary>
    /// Идентификатор самолёта
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Модель самолёта
    /// </summary>
    [Column("model")]
    public required string Model { get; set; }
    /// <summary>
    /// Вместимость самолёта
    /// </summary>
    [Column("capacity")]
    public required double Capacity { get; set; }

    /// <summary>
    /// Производительность самолёта
    /// </summary>
    [Column("efficiency")]
    public required double Efficiency { get; set; }

    /// <summary>
    /// Максимальное число пассажиров
    /// </summary>
    [Column("max_passenger")]
    public required int MaxPassenger { get; set; }
}