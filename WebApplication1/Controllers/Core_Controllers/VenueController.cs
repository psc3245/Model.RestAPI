using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.Venue;
using WebApplication1.Entities;
// Correct namespace for Venue DTOs

namespace WebApplication1.Controllers;

[ApiController]
public class VenueController : ControllerBase
{
    private readonly SportsDbContext _context;

    public VenueController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all venues.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenues()
    {
        var venues = await _context.Venues
            .Select(v => new VenueDto
            {
                VenueId = v.VenueId,
                Name = v.Name,
                City = v.City,
                State = v.State,
                Country = v.Country,
                Capacity = v.Capacity,
                Location = v.Location
            })
            .ToListAsync();

        return Ok(venues);
    }

    /// <summary>
    ///     Gets a specific venue by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the venue.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<VenueDto>> GetVenue(Guid id)
    {
        var venue = await _context.Venues.FindAsync(id);

        if (venue == null) return NotFound();

        var venueDto = new VenueDto
        {
            VenueId = venue.VenueId,
            Name = venue.Name,
            City = venue.City,
            State = venue.State,
            Country = venue.Country,
            Capacity = venue.Capacity,
            Location = venue.Location
        };

        return Ok(venueDto);
    }

    /// <summary>
    ///     Creates a new venue.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<VenueDto>> CreateVenue(CreateVenueDto createDto)
    {
        var venue = new Venue
        {
            Name = createDto.Name,
            City = createDto.City,
            State = createDto.State,
            Country = createDto.Country,
            Capacity = createDto.Capacity,
            Location = createDto.Location,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Venues.Add(venue);
        await _context.SaveChangesAsync();

        var venueDto = new VenueDto
        {
            VenueId = venue.VenueId,
            Name = venue.Name,
            City = venue.City,
            State = venue.State,
            Country = venue.Country,
            Capacity = venue.Capacity,
            Location = venue.Location
        };

        return CreatedAtAction(nameof(GetVenue), new { id = venue.VenueId }, venueDto);
    }

    /// <summary>
    ///     Updates an existing venue.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenue(Guid id, UpdateVenueDto updateDto)
    {
        var venue = await _context.Venues.FindAsync(id);

        if (venue == null) return NotFound();

        venue.Name = updateDto.Name;
        venue.City = updateDto.City;
        venue.State = updateDto.State;
        venue.Country = updateDto.Country;
        venue.Capacity = updateDto.Capacity;
        venue.Location = updateDto.Location;
        venue.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a venue.
    /// </summary>
    public async Task<IActionResult> DeleteVenue(Guid id)
    {
        var venue = await _context.Venues.FindAsync(id);
        if (venue == null) return NotFound();

        _context.Venues.Remove(venue);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}