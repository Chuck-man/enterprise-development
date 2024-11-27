
namespace AirCompany.Domain.Repositories;

internal class FlightRepository : IRepository<Flight>
{
    private readonly List<Flight> _flights = [];

    public bool Delete(int id)
    {
        var value = GetId(id);

        if (value == null)
            return false;

        _flights.Remove(value);
        return true;
    }

    public IEnumerable<Flight> GetAll() => _flights;

    public Flight? GetById(int id) => _flights.Find(f => f.Id == id);

    public Flight? Post(Flight entity)
    {
        _flights.Add(entity);
        return entity;
    }

    public bool Put(int id, Flight entity)
    {
        var oldValue = GetId(id);

        if (oldValue == null)
            return false;

        oldValue.Number = entity.Number;
        oldValue.DeparturePoint = entity.DeparturePoint;
        oldValue.ArrivalPoint = entity.ArrivalPoint;
        oldValue.DepartureDate = entity.DepartureDate;
        oldValue.ArrivalDate = entity.ArrivalDate;
        oldValue.PlaneType = entity.PlaneType;
        oldValue.Passengers = entity.Passengers;
        return true;
    }
}
