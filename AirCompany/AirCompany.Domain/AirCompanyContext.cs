using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain;

/// <summary>
/// Контекст данных для базы данных авиакомпании.
/// Предоставляет доступ к наборам сущностей для работы с самолетами, рейсами, пассажирами и информацией о зарегистрированных пассажирах на рейсах.
/// </summary>
public class AirCompanyContext(DbContextOptions<AirCompanyContext> options) : DbContext(options)
{
    public DbSet<Aircraft> Aircrafts { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<RegisteredPassenger> RegisteredPassengers { get; set; }

    /// <summary>
    /// Настраивает модель данных Entity Framework Core, определяя связи между сущностями.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisteredPassenger>()
            .HasOne(rp => rp.Flight)
            .WithMany(f => f.Passengers)
            .HasForeignKey(rp => rp.FlightId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RegisteredPassenger>()
            .HasOne(rp => rp.Passenger)
            .WithMany(p => p.RegisteredPassengers)
            .HasForeignKey(rp => rp.PassengerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Flight>()
            .HasOne(f => f.PlaneType)
            .WithMany()
            .HasForeignKey(f => f.PlaneTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
