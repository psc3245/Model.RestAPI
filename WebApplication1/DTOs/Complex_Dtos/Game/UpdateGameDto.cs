namespace WebApplication1.DTOs.Complex_DTOs.Game;

public class UpdateGameDto
{
    public Guid? VenueId { get; set; }
    public DateTime GameDateTime { get; set; }
    public string Status { get; set; }
    public int? Attendance { get; set; }
    public string? Metadata { get; set; }
}