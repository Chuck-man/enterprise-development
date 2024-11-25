
namespace AirCompany.Domain.Repositories;

internal class RegisteredPassengerRepository : IRepository<RegisteredPassenger>
{
    private readonly List<RegisteredPassenger> _registeredPassengers = [];

    public bool Delete(int id)
    {
        var value = GetId(id);

        if (value == null)
            return false;

        _registeredPassengers.Remove(value);
        return true;
    }

    public IEnumerable<RegisteredPassenger> GetEntities() => _registeredPassengers;

    public RegisteredPassenger? GetId(int id) => _registeredPassengers.Find(r => r.Id == id);

    public RegisteredPassenger? Post(RegisteredPassenger entity)
    {
        _registeredPassengers.Add(entity);
        return entity;
    }

    public bool Put(int id, RegisteredPassenger entity)
    {
        var oldValue = GetId(id);

        if (oldValue == null)
            return false;

        oldValue.Number = entity.Number;
        oldValue.SeatNumber = entity.SeatNumber;
        oldValue.BaggageWeight = entity.BaggageWeight;
        oldValue.Flight = entity.Flight;
        oldValue.Passenger = entity.Passenger;
        return true;
    }
}
