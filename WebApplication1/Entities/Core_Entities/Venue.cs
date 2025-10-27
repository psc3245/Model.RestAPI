using WebApplication1.Complex_Entities;

namespace WebApplication1.Entities;

public class Venue
{
    public Guid VenueId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public int? Capacity { get; set; }

    // Maps to JSONB location coordinates
    public string Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<Game> Games { get; set; }
}