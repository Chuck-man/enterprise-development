using Microsoft.AspNetCore.Mvc;
using AirCompany.Domain;

namespace AirComany.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AircraftController : ControllerBase
{
    // GET: api/<AircraftController>
    [HttpGet]
    public IEnumerable<Aircraft> Get()
    {
        return new List<Aircraft>;
    }

    // GET api/<AircraftController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<AircraftController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<AircraftController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<AircraftController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
