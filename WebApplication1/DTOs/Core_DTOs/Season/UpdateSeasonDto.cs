namespace WebApplication1.DTOs.Core_DTOs.Season;

public class UpdateSeasonDto
{
    // Typically, you wouldn't change the LeagueId or Year of an existing season.
    // If you needed to, you would delete and recreate it.
    // We will only allow updating the dates.

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}