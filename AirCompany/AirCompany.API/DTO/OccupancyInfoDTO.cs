namespace AirCompany.API.DTO;

/// <summary>
/// DTO для информации о загрузке рейсов
/// </summary>
public class OccupancyInfoDTO
{
    /// <summary>
    /// Средняя загрузка
    /// </summary>
    public required double AverageLoad { get; set; }

    /// <summary>
    /// Максимальная загрузка
    /// </summary>
    public required int MaxLoad { get; set; }
}
