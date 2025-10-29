using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Complex_DTOs.Game;
using WebApplication1.Complex_Entities;

namespace WebApplication1.Controllers;

[ApiController]
public class GamesController : ControllerBase
{
    private readonly SportsDbContext _context;

    public GamesController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all games.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetGames()
    {
        var games = await _context.Games
        .Select(g => new GameDto
            {
                GameId = g.GameId,
                SeasonId = g.SeasonId,
                VenueId = g.VenueId,
                GameDateTime = g.GameDateTime,
                Status = g.Status,
                Attendance = g.Attendance,
                Metadata = g.Metadata
            })
        .ToListAsync();

        return Ok(games);
    }

    /// <summary>
    /// Gets a specific game by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the game.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetGame(Guid id)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        var gameDto = new GameDto
        {
            GameId = game.GameId,
            SeasonId = game.SeasonId,
            VenueId = game.VenueId,
            GameDateTime = game.GameDateTime,
            Status = game.Status,
            Attendance = game.Attendance,
            Metadata = game.Metadata
        };

        return Ok(gameDto);
    }

    /// <summary>
    /// Creates a new game.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<GameDto>> CreateGame(CreateGameDto createDto)
    {
        var game = new Game
        {
            SeasonId = createDto.SeasonId,
            VenueId = createDto.VenueId,
            GameDateTime = createDto.GameDateTime,
            Status = createDto.Status,
            Attendance = createDto.Attendance,
            Metadata = createDto.Metadata,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        var gameDto = new GameDto
        {
            GameId = game.GameId,
            SeasonId = game.SeasonId,
            VenueId = game.VenueId,
            GameDateTime = game.GameDateTime,
            Status = game.Status,
            Attendance = game.Attendance,
            Metadata = game.Metadata
        };

        return CreatedAtAction(nameof(GetGame), new { id = game.GameId }, gameDto);
    }

    /// <summary>
    /// Updates an existing game.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(Guid id, UpdateGameDto updateDto)
    {
        var game = await _context.Games.FindAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        game.VenueId = updateDto.VenueId;
        game.GameDateTime = updateDto.GameDateTime;
        game.Status = updateDto.Status;
        game.Attendance = updateDto.Attendance;
        game.Metadata = updateDto.Metadata;
        game.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a game.
    /// </summary>
   
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}