using GyungChung.API.Services;
using GyungChung.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GyungChung.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MongoService<Member> _service;

        public MembersController(MongoService<Member> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Member>> GetById(string userId)
        {
            var member = await _service.GetByIdAsync("UserId", userId);
            if (member == null) return NotFound();
            return member;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Member member)
        {
            await _service.CreateAsync(member);
            return CreatedAtAction(nameof(GetById), new { userId = member.UserID }, member);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> Update(string userId, Member member)
        {
            await _service.UpdateAsync("UserId", userId, member);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(string userId)
        {
            await _service.DeleteAsync("UserId", userId);
            return NoContent();
        }
    }
}
