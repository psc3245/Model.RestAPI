namespace WebApplication1.DTOs.Complex_Dtos.TeamSeasonDetail;

public class CreateTeamSeasonDetailDto
{
   
    public Guid TeamId { get; set; }

   
    public Guid SeasonId { get; set; }

    public Guid? HierarchyId { get; set; }

   
   
    public string NameAtTime { get; set; }

    public string? LogoUrl { get; set; }
}