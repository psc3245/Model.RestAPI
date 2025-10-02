using WebApplication1.Entities;

namespace WebApplication1.Complex_Entities;

public class Game
{
    public Guid GameId {get; set;}
    public Guid SeasonId {get; set;}
    public Guid? VenueId {get; set;}
    public DateTime GameDateTime {get; set;}
    public string Status {get; set;}
    public int? Attendance {get; set;}
    // Maps to JSONB in Postgre
    public string Metadata {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public Season Season {get; set;}
    public Venue Venue {get; set;}
    public ICollection<GameParticipant> GameParticipants {get; set;}
    public ICollection<PlayerGameStat> PlayerGameStats {get; set;}
    public ICollection<TeamGameStat> TeamGameStats {get; set;}

}