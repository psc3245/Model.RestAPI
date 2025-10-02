namespace WebApplication1.Complex_Entities;

public class GameParticipant
{
    public Guid GameParticipantId {get; set;}
    public Guid GameId {get; set;}
    public Guid TeamSeasonId {get; set;}
    public string Location {get; set;}
    public int? Score {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public Game Game {get; set;}
    public TeamSeasonDetail TeamSeasonDetail {get; set;}

}