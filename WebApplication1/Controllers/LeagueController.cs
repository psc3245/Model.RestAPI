using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaguesController : ControllerBase
{
    private readonly SportsDbContext _context;

    public LeaguesController(SportsDbContext context)
    {
        _context = context;
    }

    // GET: api/leagues
    [HttpGet]
    public async Task<ActionResult<IEnumerable<League>>> GetLeagues()
    {
        var leagues = await _context.Leagues
            .Include(l => l.Seasons)
            .Include(l => l.Teams)
            .ToListAsync();
        return Ok(leagues);
    }

    // GET: api/leagues/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<League>> GetLeague(int id)
    {
        var league = await _context.Leagues
            .Include(l => l.Seasons)
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (league == null)
            return NotFound();

        return Ok(league);
    }

    // POST: api/leagues
    [HttpPost]
    public async Task<ActionResult<League>> CreateLeague(League league)
    {
        _context.Leagues.Add(league);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLeague), new { id = league.Id }, league);
    }

    // PUT: api/leagues/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeague(int id, League league)
    {
        if (id != league.Id)
            return BadRequest();

        _context.Entry(league).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Leagues.Any(l => l.Id == id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/leagues/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeague(int id)
    {
        var league = await _context.Leagues.FindAsync(id);
        if (league == null)
            return NotFound();

        _context.Leagues.Remove(league);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
