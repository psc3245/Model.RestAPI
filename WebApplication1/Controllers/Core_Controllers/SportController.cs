using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.Sport;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SportsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public SportsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all sports.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SportDto>>> GetSports()
    {
        var sports = await _context.Sports
            .Select(s => new SportDto
            {
                SportId = s.SportId,
                Name = s.Name
            })
            .ToListAsync();

        return Ok(sports);
    }

    /// <summary>
    ///     Gets a specific sport by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the sport.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<SportDto>> GetSport(Guid id)
    {
        var sport = await _context.Sports.FindAsync(id);

        if (sport == null) return NotFound();

        var sportDto = new SportDto
        {
            SportId = sport.SportId,
            Name = sport.Name
        };

        return Ok(sportDto);
    }

    /// <summary>
    ///     Creates a new sport.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<SportDto>> CreateSport(CreateSportDto createDto)
    {
        var sport = new Sport
        {
            Name = createDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Sports.Add(sport);
        await _context.SaveChangesAsync();

        var sportDto = new SportDto
        {
            SportId = sport.SportId,
            Name = sport.Name
        };

        return CreatedAtAction(nameof(GetSport), new { id = sport.SportId }, sportDto);
    }

    /// <summary>
    ///     Updates an existing sport.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSport(Guid id, UpdateSportDto updateDto)
    {
        var sport = await _context.Sports.FindAsync(id);

        if (sport == null) return NotFound();

        sport.Name = updateDto.Name;
        sport.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a sport.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSport(Guid id)
    {
        var sport = await _context.Sports.FindAsync(id);
        if (sport == null) return NotFound();

        _context.Sports.Remove(sport);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}