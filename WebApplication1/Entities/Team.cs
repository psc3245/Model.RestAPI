namespace WebApplication1;

public class Team
{
    public int TeamId { get; set; }
    public int LeagueId { get; set; }
    public League League { get; set; }

    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Location { get; set; }
    public int FoundedYear { get; set; }

    public ICollection<Player> Players { get; set; }
    public ICollection<Game> HomeGames { get; set; }
    public ICollection<Game> AwayGames { get; set; }
}