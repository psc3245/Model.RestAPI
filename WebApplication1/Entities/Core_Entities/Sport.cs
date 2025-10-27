namespace WebApplication1.Entities;

public class Sport
{
    public Guid SportId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<League> Leagues { get; set; }
}