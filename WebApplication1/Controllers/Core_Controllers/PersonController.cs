using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Core_DTOs.Person;
using WebApplication1.Entities;

namespace WebApplication1.Controllers;

// Make sure this namespace is correct

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly SportsDbContext _context;

    public PersonsController(SportsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Gets a list of all persons (players and coaches).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
    {
        var persons = await _context.Persons
            .Select(p => new PersonDto
            {
                PersonId = p.PersonId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Nationality = p.Nationality,
                PhysicalAttributes = p.PhysicalAttributes
            })
            .ToListAsync();

        return Ok(persons);
    }

    /// <summary>
    ///     Gets a specific person by their unique ID.
    /// </summary>
    /// <param name="id">The GUID of the person.</param>
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetPerson(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);

        if (person == null) return NotFound();

        var personDto = new PersonDto
        {
            PersonId = person.PersonId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            BirthDate = person.BirthDate,
            Nationality = person.Nationality,
            PhysicalAttributes = person.PhysicalAttributes
        };

        return Ok(personDto);
    }

    /// <summary>
    ///     Creates a new person.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<PersonDto>> CreatePerson(CreatePersonDto createDto)
    {
        var person = new Person
        {
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            BirthDate = createDto.BirthDate,
            Nationality = createDto.Nationality,
            PhysicalAttributes = createDto.PhysicalAttributes,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Persons.Add(person);
        await _context.SaveChangesAsync();

        var personDto = new PersonDto
        {
            PersonId = person.PersonId,
            FirstName = person.FirstName,
            LastName = person.LastName,
            BirthDate = person.BirthDate,
            Nationality = person.Nationality,
            PhysicalAttributes = person.PhysicalAttributes
        };

        return CreatedAtAction(nameof(GetPerson), new { id = person.PersonId }, personDto);
    }

    /// <summary>
    ///     Updates an existing person.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(Guid id, UpdatePersonDto updateDto)
    {
        var person = await _context.Persons.FindAsync(id);

        if (person == null) return NotFound();

        person.FirstName = updateDto.FirstName;
        person.LastName = updateDto.LastName;
        person.BirthDate = updateDto.BirthDate;
        person.Nationality = updateDto.Nationality;
        person.PhysicalAttributes = updateDto.PhysicalAttributes;
        person.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Deletes a person.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person == null) return NotFound();

        _context.Persons.Remove(person);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}