namespace WebApplication1.DTOs.Core_DTOs.LeagueHeirarchy;

public class CreateLeagueHierarchyDto
{
    public Guid LeagueId { get; set; }

    public Guid? ParentId { get; set; } // Null if this is a top-level item


    public string Name { get; set; }
}