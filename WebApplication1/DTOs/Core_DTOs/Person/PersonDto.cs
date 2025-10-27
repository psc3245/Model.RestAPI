namespace WebApplication1.DTOs.Core_DTOs.Person;

public class PersonDto
{
    public Guid PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Nationality { get; set; }
    public string PhysicalAttributes { get; set; } // JSON data as a string
}