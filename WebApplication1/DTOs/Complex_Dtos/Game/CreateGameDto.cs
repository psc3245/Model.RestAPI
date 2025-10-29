namespace WebApplication1.DTOs.Complex_DTOs.Game;

public class CreateGameDto
{
    public Guid SeasonId { get; set; }

    public Guid? VenueId { get; set; }


    public DateTime GameDateTime { get; set; }


    public string Status { get; set; } = "Scheduled"; // Default status

    public int? Attendance { get; set; }

    public string? Metadata { get; set; } // Optional JSON data (e.g., for broadcast info)
}