using WebApplication1.Complex_Entities;

namespace WebApplication1.Entities;

public class Season
{
    public Guid SeasonId {get; set;}
    public Guid LeagueId {get; set;}
    public int Year {get; set;}
    public string Type {get; set;}
    public DateTime? StartDate {get; set;}
    public DateTime? EndDate {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public League League {get; set;}
    public ICollection<TeamSeasonDetail> TeamSeasonDetails {get; set;}
    public ICollection<Game> Games {get; set;}

}