namespace AirComany.API.DTO;

public class AircraftPostDto
{
    /// <summary>
    /// Модель самолёта
    /// </summary>
    public required string Model { get; set; } = string.Empty;
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
