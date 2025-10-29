namespace WebApplication1.DTOs.Core_DTOs.Season;

public class CreateSeasonDto
{
   
    public Guid LeagueId { get; set; }

   
    public int Year { get; set; }

   
   
    public string Type { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}