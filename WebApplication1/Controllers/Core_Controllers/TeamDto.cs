using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.Team;
using WebApplication1.Entities;
// Correct namespace for Team DTOs

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public TeamsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all teams.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
    {
        var teams = await _context.Teams
            .Select(t => new TeamDto
            {
                TeamId = t.TeamId,
                LeagueId = t.LeagueId,
                OfficialName = t.OfficialName,
                ShortName = t.ShortName,
                Abbreviation = t.Abbreviation
            })
            .ToListAsync();

        return Ok(teams);
    }

    /// <summary>
    ///     Gets a specific team by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the team.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> GetTeam(Guid id)
    {
        var team = await _context.Teams.FindAsync(id);

        if (team == null) return NotFound();

        var teamDto = new TeamDto
        {
            TeamId = team.TeamId,
            LeagueId = team.LeagueId,
            OfficialName = team.OfficialName,
            ShortName = team.ShortName,
            Abbreviation = team.Abbreviation
        };

        return Ok(teamDto);
    }

    /// <summary>
    ///     Creates a new team.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TeamDto>> CreateTeam(CreateTeamDto createDto)
    {
        var team = new Team
        {
            LeagueId = createDto.LeagueId,
            OfficialName = createDto.OfficialName,
            ShortName = createDto.ShortName,
            Abbreviation = createDto.Abbreviation,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();

        var teamDto = new TeamDto
        {
            TeamId = team.TeamId,
            LeagueId = team.LeagueId,
            OfficialName = team.OfficialName,
            ShortName = team.ShortName,
            Abbreviation = team.Abbreviation
        };

        return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, teamDto);
    }

    /// <summary>
    ///     Updates an existing team.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(Guid id, UpdateTeamDto updateDto)
    {
        var team = await _context.Teams.FindAsync(id);

        if (team == null) return NotFound();

        team.OfficialName = updateDto.OfficialName;
        team.ShortName = updateDto.ShortName;
        team.Abbreviation = updateDto.Abbreviation;
        team.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a team.
    /// </summary>
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return NotFound();

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}