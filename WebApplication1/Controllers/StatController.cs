using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatController : ControllerBase
{
    private readonly SportsDbContext _context;

    public StatController(SportsDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddStat([FromBody] StatDto dto)
    {
        if (dto.PlayerId == null && dto.TeamId == null)
            return BadRequest("Stat must belong to a player or a team.");

        var stat = new Stat
        {
            PlayerId = dto.PlayerId,
            TeamId = dto.TeamId,
            GameId = dto.GameId,
            Name = dto.Name,
            Value = dto.Value
        };

        _context.Stats.Add(stat);
        await _context.SaveChangesAsync();
        return Ok(stat);
    }
}
