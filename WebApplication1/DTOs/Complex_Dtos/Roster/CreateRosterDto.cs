namespace WebApplication1.DTOs.Complex_Dtos.Roster;

public class CreateRosterDto
{
   
    public Guid PersonId { get; set; }

   
    public Guid TeamSeasonId { get; set; }

   
   
    public string Role { get; set; }

    public int? JerseyNumber { get; set; }

   
   
    public string Status { get; set; }
}