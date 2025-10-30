using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.LeagueHeirarchy;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeagueHierarchiesController : ControllerBase
{
    private readonly SportsDbContext _context;

    public LeagueHierarchiesController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all league hierarchy items (conferences, divisions, etc.).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeagueHierarchyDto>>> GetLeagueHierarchies()
    {
        var hierarchies = await _context.LeagueHierarchies
            .Select(h => new LeagueHierarchyDto
            {
                LeagueHierarchyId = h.LeagueHierarchyId,
                LeagueId = h.LeagueId,
                ParentId = h.ParentId,
                Name = h.Name
            })
            .ToListAsync();

        return Ok(hierarchies);
    }

    /// <summary>
    ///     Gets a specific league hierarchy item by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the hierarchy item.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeagueHierarchyDto>> GetLeagueHierarchy(Guid id)
    {
        var hierarchy = await _context.LeagueHierarchies.FindAsync(id);

        if (hierarchy == null) return NotFound();

        var hierarchyDto = new LeagueHierarchyDto
        {
            LeagueHierarchyId = hierarchy.LeagueHierarchyId,
            LeagueId = hierarchy.LeagueId,
            ParentId = hierarchy.ParentId,
            Name = hierarchy.Name
        };

        return Ok(hierarchyDto);
    }

    /// <summary>
    ///     Creates a new league hierarchy item (e.g., a conference or division).
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<LeagueHierarchyDto>> CreateLeagueHierarchy(CreateLeagueHierarchyDto createDto)
    {
        var hierarchy = new LeagueHierarchy
        {
            LeagueId = createDto.LeagueId,
            ParentId = createDto.ParentId,
            Name = createDto.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.LeagueHierarchies.Add(hierarchy);
        await _context.SaveChangesAsync();

        var hierarchyDto = new LeagueHierarchyDto
        {
            LeagueHierarchyId = hierarchy.LeagueHierarchyId,
            LeagueId = hierarchy.LeagueId,
            ParentId = hierarchy.ParentId,
            Name = hierarchy.Name
        };

        return CreatedAtAction(nameof(GetLeagueHierarchy), new { id = hierarchy.LeagueHierarchyId }, hierarchyDto);
    }

    /// <summary>
    ///     Updates an existing league hierarchy item.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeagueHierarchy(Guid id, UpdateLeagueHierarchyDto updateDto)
    {
        var hierarchy = await _context.LeagueHierarchies.FindAsync(id);

        if (hierarchy == null) return NotFound();

        hierarchy.Name = updateDto.Name;
        hierarchy.ParentId = updateDto.ParentId;
        hierarchy.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a league hierarchy item.
    /// </summary>
    public async Task<IActionResult> DeleteLeagueHierarchy(Guid id)
    {
        var hierarchy = await _context.LeagueHierarchies.FindAsync(id);
        if (hierarchy == null) return NotFound();

        // Note: You may need to add logic here to handle what happens to children 
        // of a deleted hierarchy item (e.g., re-parent them or delete them).
        // For now, we'll just remove the item itself.

        _context.LeagueHierarchies.Remove(hierarchy);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}