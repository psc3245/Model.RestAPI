namespace WebApplication1.DTOs.Core_DTOs.Season;

public class SeasonDto
{
    public Guid SeasonId { get; set; }
    public Guid LeagueId { get; set; }
    public int Year { get; set; }
    public string Type { get; set; } // e.g., "Regular Season", "Postseason"
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}