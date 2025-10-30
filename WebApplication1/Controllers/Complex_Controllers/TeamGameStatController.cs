using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Complex_Entities;
using WebApplication1.DTOs.Complex_Dtos.TeamGameStat;

namespace WebApplication1.Controllers;

[ApiController]
public class TeamGameStatsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public TeamGameStatsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all team game stat records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamGameStatDto>>> GetTeamGameStats()
    {
        var stats = await _context.TeamGameStats
         .Select(t => new TeamGameStatDto
            {
                TeamGameStatId = t.TeamGameStatId,
                GameId = t.GameId,
                TeamSeasonId = t.TeamSeasonId,
                Stats = t.Stats
            })
         .ToListAsync();

        return Ok(stats);
    }

    /// <summary>
    /// Gets a specific team game stat record by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the team game stat record.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamGameStatDto>> GetTeamGameStat(Guid id)
    {
        var stat = await _context.TeamGameStats.FindAsync(id);

        if (stat == null)
        {
            return NotFound();
        }

        var statDto = new TeamGameStatDto
        {
            TeamGameStatId = stat.TeamGameStatId,
            GameId = stat.GameId,
            TeamSeasonId = stat.TeamSeasonId,
            Stats = stat.Stats
        };

        return Ok(statDto);
    }

    /// <summary>
    /// Creates a new team game stat record.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TeamGameStatDto>> CreateTeamGameStat(CreateTeamGameStatDto createDto)
    {
        var stat = new TeamGameStat
        {
            GameId = createDto.GameId,
            TeamSeasonId = createDto.TeamSeasonId,
            Stats = createDto.Stats,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.TeamGameStats.Add(stat);
        await _context.SaveChangesAsync();

        var statDto = new TeamGameStatDto
        {
            TeamGameStatId = stat.TeamGameStatId,
            GameId = stat.GameId,
            TeamSeasonId = stat.TeamSeasonId,
            Stats = stat.Stats
        };

        return CreatedAtAction(nameof(GetTeamGameStat), new { id = stat.TeamGameStatId }, statDto);
    }

    /// <summary>
    /// Updates an existing team game stat record.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeamGameStat(Guid id, UpdateTeamGameStatDto updateDto)
    {
        var stat = await _context.TeamGameStats.FindAsync(id);

        if (stat == null)
        {
            return NotFound();
        }

        stat.Stats = updateDto.Stats;
        stat.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a team game stat record.
    /// </summary>
   
    public async Task<IActionResult> DeleteTeamGameStat(Guid id)
    {
        var stat = await _context.TeamGameStats.FindAsync(id);
        if (stat == null)
        {
            return NotFound();
        }

        _context.TeamGameStats.Remove(stat);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}