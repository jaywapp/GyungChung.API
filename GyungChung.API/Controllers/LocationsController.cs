using GyungChung.API.Models;
using GyungChung.API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly MongoService<Location> _service;

    public LocationsController(MongoService<Location> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> GetAll()
        => await _service.GetAllAsync();

    [HttpGet("{locationId}")]
    public async Task<ActionResult<Location>> GetById(string locationId)
    {
        var location = await _service.GetByIdAsync("LocationID", locationId);
        if (location == null) return NotFound();
        return location;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Location location)
    {
        await _service.CreateAsync(location);
        return CreatedAtAction(nameof(GetById), new { locationId = location.LocationID }, location);
    }

    [HttpPut("{locationId}")]
    public async Task<ActionResult> Update(string locationId, Location location)
    {
        await _service.UpdateAsync("LocationID", locationId, location);
        return NoContent();
    }

    [HttpDelete("{locationId}")]
    public async Task<ActionResult> Delete(string locationId)
    {
        await _service.DeleteAsync("LocationID", locationId);
        return NoContent();
    }
}
