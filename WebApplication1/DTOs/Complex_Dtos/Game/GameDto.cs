// DTOs/Complex_DTOs/Game/GameDto.cs
namespace WebApplication1.DTOs.Complex_DTOs.Game;

public class GameDto
{
    public Guid GameId { get; set; }
    public Guid SeasonId { get; set; }
    public Guid? VenueId { get; set; }
    public DateTime GameDateTime { get; set; }
    public string Status { get; set; }
    public int? Attendance { get; set; }
    public string? Metadata { get; set; } // JSON data as a string
}