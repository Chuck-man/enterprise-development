namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий информацию о самолете для передачи данных.
/// </summary>
public class AircraftDto
{
    /// <summary>
    /// Модель самолёта
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Вместимость самолёта
    /// </summary>
    public required double Capacity { get; set; }

    /// <summary>
    /// Производительность самолёта
    /// </summary>
    public required double Efficiency { get; set; }

    /// <summary>
    /// Максимальное число пассажиров
    /// </summary>
    public required int MaxPassenger { get; set; }
}
