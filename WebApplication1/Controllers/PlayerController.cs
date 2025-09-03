using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly SportsDbContext _context;

    public PlayerController(SportsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Players.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var player = _context.Players.Find(id);
        if (player == null) return NotFound();
        return Ok(player);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
        return Ok(player);
    }
}
