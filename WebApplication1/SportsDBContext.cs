using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class SportsDbContext : DbContext
{
    public SportsDbContext(DbContextOptions<SportsDbContext> options)
        : base(options)
    {
    }

    public DbSet<League> Leagues { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<TeamBoxScore> Games { get; set; }
    public DbSet<Stat> Stats { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TeamBoxScore>()
            .HasOne(g => g.HomeTeam)
            .WithMany(t => t.HomeGames)
            .HasForeignKey(g => g.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TeamBoxScore>()
            .HasOne(g => g.AwayTeam)
            .WithMany(t => t.AwayGames)
            .HasForeignKey(g => g.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<League>().HasData(
            new League { Id = 1, Name = "NFL", Sport = "Football", Country = "USA" }
        );

        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "New England Patriots", Abbreviation = "NE", Location = "Foxborough, MA", LeagueId = 1 },
            new Team { Id = 2, Name = "Miami Dolphins", Abbreviation = "MIA", Location = "Miami, FL", LeagueId = 1 }
        );

        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Mac Jones", Position = "QB", Number = 10, TeamId = 1 },
            new Player { Id = 2, Name = "Tua Tagovailoa", Position = "QB", Number = 1, TeamId = 2 }
        );

        modelBuilder.Entity<TeamBoxScore>().HasData(
            new TeamBoxScore { Id = 1, HomeTeamId = 1, AwayTeamId = 2, Date = new DateTime(2025, 9, 7, 13, 0, 0) }
        );
    }

}