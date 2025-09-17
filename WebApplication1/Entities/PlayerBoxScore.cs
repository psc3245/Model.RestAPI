namespace WebApplication1;

public class PlayerBoxScore
{
    public int PlayerId { get; set; }
    public int GameId { get; set; }
    public DateTime Date { get; set; } 
    public ICollection<Stat> BoxScore { get; set; } = new List<Stat>();
    
}