namespace WebApplication1.DTOs.Core_DTOs.LeagueHeirarchy;

public class UpdateLeagueHierarchyDto
{
    public string Name { get; set; }

    // Allow changing the parent of a division/conference
    public Guid? ParentId { get; set; }
}