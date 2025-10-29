namespace WebApplication1.DTOs.Core_DTOs.Team;

public class CreateTeamDto
{
    public Guid LeagueId { get; set; }


    public string OfficialName { get; set; }

    public string? ShortName { get; set; }


    public string Abbreviation { get; set; }
}