using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly SportsDbContext _context;

    public GameController(SportsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Games.ToList());

    [HttpPost]
    public IActionResult Add([FromBody] TeamBoxScore teamBoxScore)
    {
        _context.Games.Add(teamBoxScore);
        _context.SaveChanges();
        return Ok(teamBoxScore);
    }
}
