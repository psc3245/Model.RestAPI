namespace WebApplication1;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Location { get; set; }

    public int LeagueId { get; set; }
    // public League League { get; set; }

    public ICollection<Player> Players { get; set; } = new List<Player>();
    public ICollection<TeamBoxScore> HomeGames { get; set; } = new List<TeamBoxScore>();
    public ICollection<TeamBoxScore> AwayGames { get; set; } = new List<TeamBoxScore>();
    public ICollection<Stat> TeamStats { get; set; } =  new List<Stat>();
}