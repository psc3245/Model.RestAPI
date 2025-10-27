namespace WebApplication1.DTOs.Core_DTOs;

public class LeagueDto
{
    public Guid LeagueId { get; set; }
    public Guid SportId { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Level { get; set; }
    public string Metadata { get; set; }
}