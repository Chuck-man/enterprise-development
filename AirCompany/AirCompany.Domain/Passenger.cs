namespace AirCompany.Domain;

/// <summary>
/// Класс, предстваляющий информацию о пассажире
/// </summary>
/// <param name="id">Идентификатор пассажира</param>
/// <param name="passportNumber">Номер паспорта пассажира</param>
/// <param name="fullName">ФИО пассажира</param>
public class Passenger
    (
    int id,
    string? passportNumber,
    string? fullName
    )
{
    /// <summary>
    /// Идентификатор пассажира
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    public string? PassportNumber { get; set; } = passportNumber;

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    public string? FullName { get; set; } = fullName;
}

