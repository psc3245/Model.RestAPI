namespace WebApplication1;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }      // "NFL", "NBA"
    public string Sport { get; set; }     // "Football", "Basketball"
    public string Country { get; set; }

    public ICollection<Season> Seasons { get; set; } = new List<Season>();
    public ICollection<Team> Teams { get; set; } = new List<Team>();
}