using WebApplication1.Complex_Entities;

namespace WebApplication1.Entities;

public class Person
{
    public Guid PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }

    public string Nationality { get; set; }

    // Maps ot JSONB in Postgre
    public string PhysicalAttributes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Roster> Rosters { get; set; }
    public ICollection<PlayerGameStat> PlayerGameStats { get; set; }
}