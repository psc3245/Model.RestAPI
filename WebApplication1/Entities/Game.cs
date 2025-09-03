namespace WebApplication1;


public class Game
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int SeasonId { get; set; }
    public Season Season { get; set; }

    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }

    public ICollection<Stat> Stats { get; set; } = new List<Stat>();
}