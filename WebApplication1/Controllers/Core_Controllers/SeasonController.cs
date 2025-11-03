using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.Season;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeasonsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public SeasonsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all seasons.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons()
    {
        var seasons = await _context.Seasons
            .Select(s => new SeasonDto
            {
                SeasonId = s.SeasonId,
                LeagueId = s.LeagueId,
                Year = s.Year,
                Type = s.Type,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            })
            .ToListAsync();

        return Ok(seasons);
    }

    /// <summary>
    ///     Gets a specific season by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the season.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<SeasonDto>> GetSeason(Guid id)
    {
        var season = await _context.Seasons.FindAsync(id);

        if (season == null) return NotFound();

        var seasonDto = new SeasonDto
        {
            SeasonId = season.SeasonId,
            LeagueId = season.LeagueId,
            Year = season.Year,
            Type = season.Type,
            StartDate = season.StartDate,
            EndDate = season.EndDate
        };

        return Ok(seasonDto);
    }

    /// <summary>
    ///     Creates a new season.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<SeasonDto>> CreateSeason(CreateSeasonDto createDto)
    {
        var season = new Season
        {
            LeagueId = createDto.LeagueId,
            Year = createDto.Year,
            Type = createDto.Type,
            StartDate = createDto.StartDate,
            EndDate = createDto.EndDate,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Seasons.Add(season);
        await _context.SaveChangesAsync();

        var seasonDto = new SeasonDto
        {
            SeasonId = season.SeasonId,
            LeagueId = season.LeagueId,
            Year = season.Year,
            Type = season.Type,
            StartDate = season.StartDate,
            EndDate = season.EndDate
        };

        return CreatedAtAction(nameof(GetSeason), new { id = season.SeasonId }, seasonDto);
    }

    /// <summary>
    ///     Updates an existing season's dates.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSeason(Guid id, UpdateSeasonDto updateDto)
    {
        var season = await _context.Seasons.FindAsync(id);

        if (season == null) return NotFound();

        season.StartDate = updateDto.StartDate;
        season.EndDate = updateDto.EndDate;
        season.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a season.
    /// </summary>
   [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeason(Guid id)
    {
        var season = await _context.Seasons.FindAsync(id);
        if (season == null) return NotFound();

        _context.Seasons.Remove(season);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}