namespace WebApplication1.DTOs.Core_DTOs.Venue;

public class CreateVenueDto
{
   
   
    public string Name { get; set; }

    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public int? Capacity { get; set; }
    public string? Location { get; set; } // e.g., "{ \"latitude\": 40.7128, \"longitude\": -74.0060 }"
}