namespace WebApplication1.DTOs.Complex_Dtos.TeamSeasonDetail;

public class TeamSeasonDetailDto
{
    public Guid TeamSeasonDetailId { get; set; }
    public Guid TeamId { get; set; }
    public Guid SeasonId { get; set; }
    public Guid? HierarchyId { get; set; } // The division/conference for that season
    public string NameAtTime { get; set; }
    public string? LogoUrl { get; set; }
}