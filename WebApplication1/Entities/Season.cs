namespace WebApplication1;

public class Season
{
    public int SeasonId { get; set; }
    public int LeagueId { get; set; }
    public League League { get; set; }

    public int Year { get; set; }
    public string Name { get; set; }  // "2024-25 Season"

    public ICollection<Game> Games { get; set; }
}