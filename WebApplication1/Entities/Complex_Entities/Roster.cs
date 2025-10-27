using WebApplication1.Entities;

namespace WebApplication1.Complex_Entities;

public class Roster
{
    public Guid RosterId { get; set; }
    public Guid PersonId { get; set; }
    public Guid TeamSeasonId { get; set; }
    public string Role { get; set; }
    public int? JerseyNumber { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Person Person { get; set; }
    public TeamSeasonDetail TeamSeasonDetail { get; set; }
}