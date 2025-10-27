using WebApplication1.Complex_Entities;

namespace WebApplication1.Entities;

public class Team
{
    public Guid TeamId { get; set; }
    public Guid LeagueId { get; set; }
    public string OfficialName { get; set; }
    public string ShortName { get; set; }
    public string Abbreviation { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public League League { get; set; }
    public ICollection<TeamSeasonDetail> TeamSeasonDetails { get; set; }
}