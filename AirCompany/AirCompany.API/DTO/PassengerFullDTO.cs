namespace AirCompany.API.DTO;

/// <summary>
/// Класс, представляющий полную информацию о пассажире для передачи данных.
/// </summary>
public class PassengerFullDTO
{
    /// <summary>
    /// Идентификатор пассажира
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира
    /// </summary>
    public required string PassportNumber { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    public required string FullName { get; set; }
}
