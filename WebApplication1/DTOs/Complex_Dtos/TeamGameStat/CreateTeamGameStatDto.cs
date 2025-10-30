namespace WebApplication1.DTOs.Complex_Dtos.TeamGameStat;

public class CreateTeamGameStatDto
{
   
    public Guid GameId { get; set; }

   
    public Guid TeamSeasonId { get; set; }

   
   
    public string Stats { get; set; }
}