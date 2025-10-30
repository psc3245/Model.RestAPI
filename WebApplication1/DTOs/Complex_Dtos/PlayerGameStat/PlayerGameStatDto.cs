namespace WebApplication1.DTOs.Complex_Dtos.PlayerGameStat;

public class PlayerGameStatDto
{
    public Guid PlayerGameStatId { get; set; }
    public Guid GameId { get; set; }
    public Guid PersonId { get; set; }
    public Guid TeamSeasonId { get; set; }
    public string Stats { get; set; } // The JSON stats object as a string
}