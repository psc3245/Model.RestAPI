using WebApplication1.Complex_Entities;
using WebApplication1.DTOs.Complex_Dtos.Roster;

namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class RostersController : ControllerBase
{
    private readonly SportsDbContext _context;

    public RostersController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all roster entries.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RosterDto>>> GetRosters()
    {
        var rosters = await _context.Rosters
         .Select(r => new RosterDto
            {
                RosterId = r.RosterId,
                PersonId = r.PersonId,
                TeamSeasonId = r.TeamSeasonId,
                Role = r.Role,
                JerseyNumber = r.JerseyNumber,
                Status = r.Status
            })
         .ToListAsync();

        return Ok(rosters);
    }

    /// <summary>
    /// Gets a specific roster entry by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the roster entry.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<RosterDto>> GetRoster(Guid id)
    {
        var roster = await _context.Rosters.FindAsync(id);

        if (roster == null)
        {
            return NotFound();
        }

        var rosterDto = new RosterDto
        {
            RosterId = roster.RosterId,
            PersonId = roster.PersonId,
            TeamSeasonId = roster.TeamSeasonId,
            Role = roster.Role,
            JerseyNumber = roster.JerseyNumber,
            Status = roster.Status
        };

        return Ok(rosterDto);
    }

    /// <summary>
    /// Creates a new roster entry (adds a person to a team for a season).
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<RosterDto>> CreateRoster(CreateRosterDto createDto)
    {
        var roster = new Roster
        {
            PersonId = createDto.PersonId,
            TeamSeasonId = createDto.TeamSeasonId,
            Role = createDto.Role,
            JerseyNumber = createDto.JerseyNumber,
            Status = createDto.Status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Rosters.Add(roster);
        await _context.SaveChangesAsync();

        var rosterDto = new RosterDto
        {
            RosterId = roster.RosterId,
            PersonId = roster.PersonId,
            TeamSeasonId = roster.TeamSeasonId,
            Role = roster.Role,
            JerseyNumber = roster.JerseyNumber,
            Status = roster.Status
        };

        return CreatedAtAction(nameof(GetRoster), new { id = roster.RosterId }, rosterDto);
    }

    /// <summary>
    /// Updates an existing roster entry.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoster(Guid id, UpdateRosterDto updateDto)
    {
        var roster = await _context.Rosters.FindAsync(id);

        if (roster == null)
        {
            return NotFound();
        }

        roster.Role = updateDto.Role;
        roster.JerseyNumber = updateDto.JerseyNumber;
        roster.Status = updateDto.Status;
        roster.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a roster entry.
    /// </summary>
   
    public async Task<IActionResult> DeleteRoster(Guid id)
    {
        var roster = await _context.Rosters.FindAsync(id);
        if (roster == null)
        {
            return NotFound();
        }

        _context.Rosters.Remove(roster);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}