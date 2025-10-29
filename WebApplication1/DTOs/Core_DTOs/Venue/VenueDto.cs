namespace WebApplication1.DTOs.Core_DTOs.Venue;

public class VenueDto
{
    public Guid VenueId { get; set; }
    public string Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public int? Capacity { get; set; }
    public string? Location { get; set; } // JSON data as a string for coordinates
}