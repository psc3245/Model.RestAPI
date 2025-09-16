namespace WebApplication1;


public class TeamBoxScore
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int SeasonId { get; set; }
    public Season Season { get; set; }

    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }
    
    public int HomeTeamScore { get; set; }

    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }
    
    public int AwayTeamScore { get; set; }
    

    public ICollection<Stat> BoxScore { get; set; } = new List<Stat>();
}