using AMIProjectAPI.Helpers;
using AMIProjectAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMIProjectAPI.Controllers.Secured
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MetersController : ControllerBase
    {
        private readonly AmiprojectContext _context;
        public MetersController(AmiprojectContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = HttpContext.User;
            if (user.IsUser())
                return Ok(await _context.Meters.ToListAsync());

            var consumerId = user.GetConsumerId();
            if (consumerId.HasValue)
            {
                var result = await _context.Meters.Where(m => m.ConsumerId == consumerId).ToListAsync();
                return Ok(result);
            }

            return Forbid();
        }

        [HttpGet("{serial}")]
        public async Task<IActionResult> Get(string serial)
        {
            var meter = await _context.Meters.FindAsync(serial);
            if (meter == null) return NotFound();

            var user = HttpContext.User;
            if (user.IsUser()) return Ok(meter);

            var consumerId = user.GetConsumerId();
            if (consumerId == meter.ConsumerId) return Ok(meter);

            return Forbid();
        }
    }
}
