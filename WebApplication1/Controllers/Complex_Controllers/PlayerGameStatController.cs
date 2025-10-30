using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Complex_Entities;
using WebApplication1.DTOs.Complex_Dtos.PlayerGameStat;

namespace WebApplication1.Controllers;

[ApiController]
public class PlayerGameStatsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public PlayerGameStatsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all player game stat records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerGameStatDto>>> GetPlayerGameStats()
    {
        var stats = await _context.PlayerGameStats
          .Select(p => new PlayerGameStatDto
            {
                PlayerGameStatId = p.PlayerGameStatId,
                GameId = p.GameId,
                PersonId = p.PersonId,
                TeamSeasonId = p.TeamSeasonId,
                Stats = p.Stats
            })
          .ToListAsync();

        return Ok(stats);
    }

    /// <summary>
    /// Gets a specific player game stat record by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the player game stat record.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerGameStatDto>> GetPlayerGameStat(Guid id)
    {
        var stat = await _context.PlayerGameStats.FindAsync(id);

        if (stat == null)
        {
            return NotFound();
        }

        var statDto = new PlayerGameStatDto
        {
            PlayerGameStatId = stat.PlayerGameStatId,
            GameId = stat.GameId,
            PersonId = stat.PersonId,
            TeamSeasonId = stat.TeamSeasonId,
            Stats = stat.Stats
        };

        return Ok(statDto);
    }

    /// <summary>
    /// Creates a new player game stat record.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<PlayerGameStatDto>> CreatePlayerGameStat(CreatePlayerGameStatDto createDto)
    {
        var stat = new PlayerGameStat
        {
            GameId = createDto.GameId,
            PersonId = createDto.PersonId,
            TeamSeasonId = createDto.TeamSeasonId,
            Stats = createDto.Stats,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.PlayerGameStats.Add(stat);
        await _context.SaveChangesAsync();

        var statDto = new PlayerGameStatDto
        {
            PlayerGameStatId = stat.PlayerGameStatId,
            GameId = stat.GameId,
            PersonId = stat.PersonId,
            TeamSeasonId = stat.TeamSeasonId,
            Stats = stat.Stats
        };

        return CreatedAtAction(nameof(GetPlayerGameStat), new { id = stat.PlayerGameStatId }, statDto);
    }

    /// <summary>
    /// Updates an existing player game stat record.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayerGameStat(Guid id, UpdatePlayerGameStatDto updateDto)
    {
        var stat = await _context.PlayerGameStats.FindAsync(id);

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
    /// Deletes a player game stat record.
    /// </summary>
   
    public async Task<IActionResult> DeletePlayerGameStat(Guid id)
    {
        var stat = await _context.PlayerGameStats.FindAsync(id);
        if (stat == null)
        {
            return NotFound();
        }

        _context.PlayerGameStats.Remove(stat);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}