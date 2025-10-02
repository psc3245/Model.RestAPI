using WebApplication1.Entities;

namespace WebApplication1.Complex_Entities;

public class PlayerGameStat
{
    public Guid PlayerGameStatId {get; set;}
    public Guid GameId {get; set;}
    public Guid PersonId {get; set;}
    public Guid TeamSeasonId {get; set;}
    // Maps to JSONB in Postgre
    public string Stats {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public Game Game {get; set;}
    public Person Person {get; set;}
    public TeamSeasonDetail TeamSeasonDetail {get; set;}

}