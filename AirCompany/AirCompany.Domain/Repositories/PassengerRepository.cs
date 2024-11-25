
namespace AirCompany.Domain.Repositories;

internal class PassengerRepository : IRepository<Passenger>
{
    private readonly List<Passenger> _passengers = [];

    public bool Delete(int id)
    {
        var value = GetId(id);

        if (value == null)
            return false;

        _passengers.Remove(value);
        return true;
    }

    public IEnumerable<Passenger> GetEntities() => _passengers;

    public Passenger? GetId(int id) => _passengers.Find(p => p.Id == id);

    public Passenger? Post(Passenger entity)
    {
        _passengers.Add(entity);
        return entity;
    }

    public bool Put(int id, Passenger entity)
    {
        var oldValue = GetId(id);

        if (oldValue == null)
            return false;

        oldValue.PassportNumber = entity.PassportNumber;
        oldValue.FullName = entity.FullName;
        return true;
    }
}
