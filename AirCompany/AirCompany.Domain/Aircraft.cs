namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о самолёте
/// </summary>
/// <param name="id">Идентификатор самолёта</param>
/// <param name="model">Модель самолёта</param>
/// <param name="capacity">Вместимость самолёта</param>
/// <param name="efficiency">Производительность самолёта</param>
/// <param name="maxPassenger">Максимальное число пассажиров</param>
public class Aircraft
    (
    int id,
    string? model,
    double? capacity,
    double? efficiency,
    int? maxPassenger
    )
{
    /// <summary>
    /// Идентификатор самолёта
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Модель самолёта
    /// </summary>
    public string? Model { get; set; } = model;

    /// <summary>
    /// Вместимость самолёта
    /// </summary>
    public double? Capacity { get; set; } = capacity;

    /// <summary>
    /// Производительность самолёта
    /// </summary>
    public double? Efficiency { get; set; } = efficiency;

    /// <summary>
    /// Максимальное число пассажиров
    /// </summary>
    public int? MaxPassenger { get; set; } = maxPassenger;
}