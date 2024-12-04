namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий информацию о пассажире для передачи данных.
/// </summary>
public class PassengerDTO
{
    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    public required string FullName { get; set; }
}
