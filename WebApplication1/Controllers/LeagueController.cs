using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[ApiController]
public class LeaguesController : ControllerBase
{
    private readonly SportsDbContext _context;

    // The DbContext is injected via the constructor (Dependency Injection)
    public LeaguesController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all leagues.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeagueDto>>> GetLeagues()
    {
        var leagues = await _context.Leagues
           .Select(l => new LeagueDto
            {
                LeagueId = l.LeagueId,
                SportId = l.SportId,
                Name = l.Name,
                Abbreviation = l.Abbreviation,
                Level = l.Level,
                Metadata = l.Metadata
            })
           .ToListAsync();

        return Ok(leagues);
    }

    /// <summary>
    /// Gets a specific league by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the league.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeagueDto>> GetLeague(Guid id)
    {
        var league = await _context.Leagues.FindAsync(id);

        if (league == null)
        {
            return NotFound(); // Returns a 404 Not Found if the league doesn't exist
        }

        var leagueDto = new LeagueDto
        {
            LeagueId = league.LeagueId,
            SportId = league.SportId,
            Name = league.Name,
            Abbreviation = league.Abbreviation,
            Level = league.Level,
            Metadata = league.Metadata
        };

        return Ok(leagueDto);
    }

    /// <summary>
    /// Creates a new league.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<LeagueDto>> CreateLeague(CreateLeagueDto createLeagueDto)
    {
        var league = new League
        {
            SportId = createLeagueDto.SportId,
            Name = createLeagueDto.Name,
            Abbreviation = createLeagueDto.Abbreviation,
            Level = createLeagueDto.Level,
            Metadata = createLeagueDto.Metadata,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Leagues.Add(league);
        await _context.SaveChangesAsync();

        var leagueDto = new LeagueDto
        {
            LeagueId = league.LeagueId,
            SportId = league.SportId,
            Name = league.Name,
            Abbreviation = league.Abbreviation,
            Level = league.Level,
            Metadata = league.Metadata
        };

        // Returns a 201 Created status with a Location header pointing to the new resource
        return CreatedAtAction(nameof(GetLeague), new { id = league.LeagueId }, leagueDto);
    }

    /// <summary>
    /// Updates an existing league.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeague(Guid id, UpdateLeagueDto updateLeagueDto)
    {
        var league = await _context.Leagues.FindAsync(id);

        if (league == null)
        {
            return NotFound();
        }

        // Map properties from the DTO to the entity
        league.Name = updateLeagueDto.Name;
        league.Abbreviation = updateLeagueDto.Abbreviation;
        league.Level = updateLeagueDto.Level;
        league.Metadata = updateLeagueDto.Metadata;
        league.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent(); // Returns a 204 No Content, the standard for a successful PUT
    }

    /// <summary>
    /// Deletes a league.
    /// </summary>
   
    public async Task<IActionResult> DeleteLeague(Guid id)
    {
        var league = await _context.Leagues.FindAsync(id);
        if (league == null)
        {
            return NotFound();
        }

        _context.Leagues.Remove(league);
        await _context.SaveChangesAsync();

        return NoContent(); // Returns a 204 No Content, the standard for a successful DELETE
    }
}