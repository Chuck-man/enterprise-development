namespace AirComany.API.DTO;

public class PassengerGetDto
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
