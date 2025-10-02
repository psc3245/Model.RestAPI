using WebApplication1.Complex_Entities;

namespace WebApplication1.Entities;

public class LeagueHierarchy
{
    public Guid LeagueHierarchyId {get; set;}
    public Guid LeagueId {get; set;}
    public Guid? ParentId {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public League League {get; set;}
    public LeagueHierarchy Parent {get; set;}
    public ICollection<LeagueHierarchy> Children {get; set;}
    public ICollection<TeamSeasonDetail> TeamSeasonDetails {get; set;}


}