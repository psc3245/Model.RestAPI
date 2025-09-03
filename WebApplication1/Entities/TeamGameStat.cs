namespace WebApplication1;

public class TeamGameStat
{
    public int TeamGameStatsId { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public string StatCategory { get; set; } // "TotalYards", "Turnovers", "Possession"
    public double StatValue { get; set; }
}