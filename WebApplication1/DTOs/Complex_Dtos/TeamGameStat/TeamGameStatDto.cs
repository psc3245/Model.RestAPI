namespace WebApplication1.DTOs.Complex_Dtos.TeamGameStat;

public class TeamGameStatDto
{
    public Guid TeamGameStatId { get; set; }
    public Guid GameId { get; set; }
    public Guid TeamSeasonId { get; set; }
    public string Stats { get; set; } // The JSON stats object as a string
}