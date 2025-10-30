namespace WebApplication1.DTOs.Complex_Dtos.GameParticipant;

public class CreateGameParticipantDto
{
    public Guid GameId { get; set; }


    public Guid TeamSeasonId { get; set; }


    public string Location { get; set; }

    public int? Score { get; set; }
}