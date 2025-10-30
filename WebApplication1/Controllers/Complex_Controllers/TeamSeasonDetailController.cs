using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Complex_Entities;
using WebApplication1.DTOs.Complex_Dtos.TeamSeasonDetail;

namespace WebApplication1.Controllers;

[ApiController]
public class TeamSeasonDetailsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public TeamSeasonDetailsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all team season detail records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamSeasonDetailDto>>> GetTeamSeasonDetails()
    {
        var details = await _context.TeamSeasonDetails
        .Select(d => new TeamSeasonDetailDto
            {
                TeamSeasonDetailId = d.TeamSeasonDetailId,
                TeamId = d.TeamId,
                SeasonId = d.SeasonId,
                HierarchyId = d.HierarchyId,
                NameAtTime = d.NameAtTime,
                LogoUrl = d.LogoUrl
            })
        .ToListAsync();

        return Ok(details);
    }

    /// <summary>
    /// Gets a specific team season detail record by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the team season detail record.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamSeasonDetailDto>> GetTeamSeasonDetail(Guid id)
    {
        var detail = await _context.TeamSeasonDetails.FindAsync(id);

        if (detail == null)
        {
            return NotFound();
        }

        var detailDto = new TeamSeasonDetailDto
        {
            TeamSeasonDetailId = detail.TeamSeasonDetailId,
            TeamId = detail.TeamId,
            SeasonId = detail.SeasonId,
            HierarchyId = detail.HierarchyId,
            NameAtTime = detail.NameAtTime,
            LogoUrl = detail.LogoUrl
        };

        return Ok(detailDto);
    }

    /// <summary>
    /// Creates a new team season detail record.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TeamSeasonDetailDto>> CreateTeamSeasonDetail(CreateTeamSeasonDetailDto createDto)
    {
        var detail = new TeamSeasonDetail
        {
            TeamId = createDto.TeamId,
            SeasonId = createDto.SeasonId,
            HierarchyId = createDto.HierarchyId,
            NameAtTime = createDto.NameAtTime,
            LogoUrl = createDto.LogoUrl,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.TeamSeasonDetails.Add(detail);
        await _context.SaveChangesAsync();

        var detailDto = new TeamSeasonDetailDto
        {
            TeamSeasonDetailId = detail.TeamSeasonDetailId,
            TeamId = detail.TeamId,
            SeasonId = detail.SeasonId,
            HierarchyId = detail.HierarchyId,
            NameAtTime = detail.NameAtTime,
            LogoUrl = detail.LogoUrl
        };

        return CreatedAtAction(nameof(GetTeamSeasonDetail), new { id = detail.TeamSeasonDetailId }, detailDto);
    }

    /// <summary>
    /// Updates an existing team season detail record.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeamSeasonDetail(Guid id, UpdateTeamSeasonDetailDto updateDto)
    {
        var detail = await _context.TeamSeasonDetails.FindAsync(id);

        if (detail == null)
        {
            return NotFound();
        }

        detail.HierarchyId = updateDto.HierarchyId;
        detail.NameAtTime = updateDto.NameAtTime;
        detail.LogoUrl = updateDto.LogoUrl;
        detail.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a team season detail record.
    /// </summary>
   
    public async Task<IActionResult> DeleteTeamSeasonDetail(Guid id)
    {
        var detail = await _context.TeamSeasonDetails.FindAsync(id);
        if (detail == null)
        {
            return NotFound();
        }

        _context.TeamSeasonDetails.Remove(detail);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}