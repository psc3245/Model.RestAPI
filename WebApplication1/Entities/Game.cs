namespace WebApplication1;

public class Game
{
    public int GameId { get; set; }

    public int SeasonId { get; set; }
    public Season Season { get; set; }

    public DateTime Date { get; set; }
    public string Round { get; set; } // e.g. "Week 1", "Quarterfinal"
    public string Venue { get; set; }

    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }

    public int HomeScore { get; set; }
    public int AwayScore { get; set; }

    public ICollection<PlayerGameStat> PlayerStats { get; set; }
    public ICollection<TeamGameStat> TeamStats { get; set; }
}