namespace WebApplication1;

public class Stat
{
    public int Id { get; set; }

    public int? PlayerId { get; set; }
    public Player Player { get; set; }

    public int? TeamId { get; set; }
    public Team Team { get; set; }

    public int GameId { get; set; }
    public Game Game { get; set; }

    public string Name { get; set; } 
    public double Value { get; set; }
}