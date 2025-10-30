namespace WebApplication1.DTOs.Complex_Dtos.PlayerGameStat;

public class CreatePlayerGameStatDto
{
   
    public Guid GameId { get; set; }

   
    public Guid PersonId { get; set; }

   
    public Guid TeamSeasonId { get; set; }

   
   
    public string Stats { get; set; }
}