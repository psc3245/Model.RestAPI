namespace WebApplication1;


public class Player
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public DateTime Birthdate { get; set; }

    public int? CurrentTeamId { get; set; }
    public Team CurrentTeam { get; set; }

    public ICollection<PlayerGameStat> GameStats { get; set; }
}