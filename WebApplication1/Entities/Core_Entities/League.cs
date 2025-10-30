namespace WebApplication1.Entities;

public class League
{
    public Guid LeagueId { get; set; }
    public Guid SportId { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }

    public string Level { get; set; }

    // Maps to JSONB in Postgre
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Sport Sport { get; set; }
    public ICollection<LeagueHierarchy> LeagueHierarchies { get; set; }
    public ICollection<Team> Teams { get; set; }
    public ICollection<Season> Seasons { get; set; }
}