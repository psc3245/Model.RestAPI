namespace WebApplication1;

public class PlayerGameStat
{
    public int PlayerGameStatsId { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    public int MinutesPlayed { get; set; }
    public string StatCategory { get; set; } // "Goals", "Assists", "PassingYards"
    public double StatValue { get; set; }
}