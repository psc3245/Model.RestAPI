namespace WebApplication1;


public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public int Number { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public ICollection<Stat> PlayerStats { get; set; } = new List<Stat>();
}