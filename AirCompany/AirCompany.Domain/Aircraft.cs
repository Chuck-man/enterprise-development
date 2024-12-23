﻿namespace AirCompany.Domain;

/// <summary>
/// Класс, представляющий информацию о самолёте
/// </summary>
public class Aircraft
{
    /// <summary>
    /// Идентификатор самолёта
    /// </summary>
    public required int Id { get; set; }

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