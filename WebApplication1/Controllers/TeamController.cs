using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly SportsDbContext _context;

    public TeamController(SportsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Teams.ToList());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var team = _context.Teams.Find(id);
        if (team == null) return NotFound();
        return Ok(team);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
        return Ok(team);
    }
}
