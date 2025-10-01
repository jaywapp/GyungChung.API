using GyungChung.API.Models;
using GyungChung.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly MongoService<Schedule> _service;

    public SchedulesController(MongoService<Schedule> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetAll()
        => await _service.GetAllAsync();

    [HttpGet("{scheduleId}")]
    public async Task<ActionResult<Schedule>> GetById(string scheduleId)
    {
        var schedule = await _service.GetByIdAsync("ScheduleID", scheduleId);
        if (schedule == null) return NotFound();
        return schedule;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Schedule schedule)
    {
        await _service.CreateAsync(schedule);
        return CreatedAtAction(nameof(GetById), new { scheduleId = schedule.ScheduleID }, schedule);
    }

    [HttpPut("{scheduleId}")]
    public async Task<ActionResult> Update(string scheduleId, Schedule schedule)
    {
        await _service.UpdateAsync("ScheduleID", scheduleId, schedule);
        return NoContent();
    }

    [HttpDelete("{scheduleId}")]
    public async Task<ActionResult> Delete(string scheduleId)
    {
        await _service.DeleteAsync("ScheduleID", scheduleId);
        return NoContent();
    }
}
