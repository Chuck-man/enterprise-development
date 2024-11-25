
namespace AirCompany.Domain.Repositories;

internal class AircraftRepository : IRepository<Aircraft>
{
    private readonly List<Aircraft> _aircrafts = [];

    public bool Delete(int id)
    {
        var value = GetId(id);
        
        if (value == null)
            return false;

        _aircrafts.Remove(value);
        return true;
    }

    public IEnumerable<Aircraft> GetEntities() => _aircrafts;

    public Aircraft? GetId(int id) => _aircrafts.Find(a => a.Id == id);

    public Aircraft? Post(Aircraft entity)
    {
        _aircrafts.Add(entity);
        return entity;
    }

    public bool Put(int id, Aircraft entity)
    {
        var oldValue = GetId(id);

        if (oldValue == null)
            return false;

        oldValue.Model = entity.Model;
        oldValue.Capacity = entity.Capacity;   
        oldValue.Efficiency = entity.Efficiency;
        oldValue.MaxPassenger = entity.MaxPassenger;
        return true;
    }
}
