namespace WebApplication1.DTOs.Core_DTOs.Person;

public class CreatePersonDto
{
    public string FirstName { get; set; }


    public string LastName { get; set; }

    public DateTime? BirthDate { get; set; }


    public string? Nationality { get; set; }

    public string? PhysicalAttributes { get; set; } // Optional JSON data
}