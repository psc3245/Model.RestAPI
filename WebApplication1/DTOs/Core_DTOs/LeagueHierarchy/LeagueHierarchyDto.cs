namespace WebApplication1.DTOs.Core_DTOs.LeagueHeirarchy;

public class LeagueHierarchyDto
{
    public Guid LeagueHierarchyId { get; set; }
    public Guid LeagueId { get; set; }
    public Guid? ParentId { get; set; } // Null for top-level items (e.g., a Conference)
    public string Name { get; set; }
}