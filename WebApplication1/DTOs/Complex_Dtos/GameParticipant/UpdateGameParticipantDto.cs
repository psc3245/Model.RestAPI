namespace WebApplication1.DTOs.Complex_Dtos.GameParticipant;

public class UpdateGameParticipantDto
{
    // The GameId, TeamSeasonId, and Location are part of the record's identity
    // and should not be changed. We only allow updating the score.
    public int? Score { get; set; }
}