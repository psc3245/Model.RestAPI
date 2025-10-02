using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Entities;

namespace WebApplication1.Complex_Entities;

public class TeamSeasonDetail
{
    public Guid TeamSeasonDetailId {get; set;}
    public Guid TeamId {get; set;}
    public Guid SeasonId {get; set;}
    public Guid? HierarchyId {get; set;}
    public string NameAtTime {get; set;}
    public string LogoUrl {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public Team Team {get; set;}
    public Season Season {get; set;}
    public LeagueHierarchy LeagueHierarchy {get; set;}
    public ICollection<Roster> Rosters {get; set;}
    public ICollection<GameParticipant> GameParticipants {get; set;}
    public ICollection<PlayerGameStat> PlayerGameStats {get; set;}
    public ICollection<TeamGameStat> TeamGameStats {get; set;}

}