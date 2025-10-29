using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Complex_Entities;
using WebApplication1.DTOs.Complex_Dtos.GameParticipant;

namespace WebApplication1.Controllers;

[ApiController]
public class GameParticipantsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public GameParticipantsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a list of all game participant records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameParticipantDto>>> GetGameParticipants()
    {
        var participants = await _context.GameParticipants
          .Select(p => new GameParticipantDto
            {
                GameParticipantId = p.GameParticipantId,
                GameId = p.GameId,
                TeamSeasonId = p.TeamSeasonId,
                Location = p.Location,
                Score = p.Score
            })
          .ToListAsync();

        return Ok(participants);
    }

    /// <summary>
    /// Gets a specific game participant record by its unique ID.
    /// </summary>
    /// <param name="id">The GUID of the game participant record.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameParticipantDto>> GetGameParticipant(Guid id)
    {
        var participant = await _context.GameParticipants.FindAsync(id);

        if (participant == null)
        {
            return NotFound();
        }

        var participantDto = new GameParticipantDto
        {
            GameParticipantId = participant.GameParticipantId,
            GameId = participant.GameId,
            TeamSeasonId = participant.TeamSeasonId,
            Location = participant.Location,
            Score = participant.Score
        };

        return Ok(participantDto);
    }

    /// <summary>
    /// Creates a new game participant record (adds a team to a game).
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<GameParticipantDto>> CreateGameParticipant(CreateGameParticipantDto createDto)
    {
        var participant = new GameParticipant
        {
            GameId = createDto.GameId,
            TeamSeasonId = createDto.TeamSeasonId,
            Location = createDto.Location,
            Score = createDto.Score,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.GameParticipants.Add(participant);
        await _context.SaveChangesAsync();

        var participantDto = new GameParticipantDto
        {
            GameParticipantId = participant.GameParticipantId,
            GameId = participant.GameId,
            TeamSeasonId = participant.TeamSeasonId,
            Location = participant.Location,
            Score = participant.Score
        };

        return CreatedAtAction(nameof(GetGameParticipant), new { id = participant.GameParticipantId }, participantDto);
    }

    /// <summary>
    /// Updates an existing game participant's score.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGameParticipant(Guid id, UpdateGameParticipantDto updateDto)
    {
        var participant = await _context.GameParticipants.FindAsync(id);

        if (participant == null)
        {
            return NotFound();
        }

        participant.Score = updateDto.Score;
        participant.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a game participant record.
    /// </summary>
   
    public async Task<IActionResult> DeleteGameParticipant(Guid id)
    {
        var participant = await _context.GameParticipants.FindAsync(id);
        if (participant == null)
        {
            return NotFound();
        }

        _context.GameParticipants.Remove(participant);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}