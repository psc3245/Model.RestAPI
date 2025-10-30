namespace WebApplication1.DTOs.Complex_Dtos.Roster;

public class RosterDto
{
    public Guid RosterId { get; set; }
    public Guid PersonId { get; set; }
    public Guid TeamSeasonId { get; set; }
    public string Role { get; set; } // e.g., "Player", "Head Coach"
    public int? JerseyNumber { get; set; }
    public string Status { get; set; } // e.g., "Active", "Injured Reserve"
}