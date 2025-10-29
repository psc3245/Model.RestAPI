namespace WebApplication1.DTOs.Core_DTOs.Team;

public class TeamDto
{
    public Guid TeamId { get; set; }
    public Guid LeagueId { get; set; }
    public string OfficialName { get; set; }
    public string? ShortName { get; set; }
    public string Abbreviation { get; set; }
}