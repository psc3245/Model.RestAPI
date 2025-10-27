namespace WebApplication1.Complex_Entities;

public class TeamGameStat
{
    public Guid TeamGameStatId { get; set; }
    public Guid GameId { get; set; }

    public Guid TeamSeasonId { get; set; }

    // Maps to JSONB in Postgre
    public string Stats { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Game Game { get; set; }
    public TeamSeasonDetail TeamSeasonDetail { get; set; }
}