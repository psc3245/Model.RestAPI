namespace WebApplication1;

public class League
{
    public int LeagueId { get; set; }
    public string Name { get; set; }      // "NFL", "NBA"
    public string Sport { get; set; }     // "Football", "Basketball"
    public string Country { get; set; }

    public ICollection<Season> Seasons { get; set; }
    public ICollection<Team> Teams { get; set; }
}