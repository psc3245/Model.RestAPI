using Microsoft.EntityFrameworkCore;
using WebApplication1.Complex_Entities;
using WebApplication1.Entities;

// Make sure to add using statements for your entity classes' namespace
// using YourProject.Domain.Entities; 

public class SportsDbContext : DbContext
{
    // The constructor accepts DbContextOptions, which allows for configuration
    // (like the connection string) to be passed in from Program.cs.
    public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options)
    {
    }

    // DbSet properties represent the tables in your database.
    // EF Core will use these to query and save data.
    public DbSet<Sport> Sports { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<LeagueHierarchy> LeagueHierarchies { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<TeamSeasonDetail> TeamSeasonDetails { get; set; }
    public DbSet<Roster> Rosters { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameParticipant> GameParticipants { get; set; }
    public DbSet<PlayerGameStat> PlayerGameStats { get; set; }
    public DbSet<TeamGameStat> TeamGameStats { get; set; }

    // The OnModelCreating method is where you configure your entity model
    // using the "Fluent API". This gives you precise control over the database schema.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- JSONB Column Configuration ---
        // Here, we explicitly tell EF Core to map the 'string' properties
        // in our C# classes to the 'jsonb' column type in PostgreSQL.
        // This is the key to our flexible statistics storage.

        modelBuilder.Entity<PlayerGameStat>()
           .Property(pgs => pgs.Stats)
           .HasColumnType("jsonb");

        modelBuilder.Entity<TeamGameStat>()
           .Property(tgs => tgs.Stats)
           .HasColumnType("jsonb");

        modelBuilder.Entity<Person>()
           .Property(p => p.PhysicalAttributes)
           .HasColumnType("jsonb");
            
        modelBuilder.Entity<Game>()
           .Property(g => g.Metadata)
           .HasColumnType("jsonb");

        modelBuilder.Entity<League>()
           .Property(l => l.Metadata)
           .HasColumnType("jsonb");

        modelBuilder.Entity<Venue>()
           .Property(v => v.Location)
           .HasColumnType("jsonb");


        // --- Unique Constraint Configuration Example ---
        // This ensures that you cannot have duplicate entries for the same
        // league, year, and season type combination.
        modelBuilder.Entity<Season>()
           .HasIndex(s => new { s.LeagueId, s.Year, s.Type })
           .IsUnique();
            
        // --- Other Configurations ---
        // You can configure relationships, composite keys, and other constraints here.
        // For example, to configure the self-referencing relationship in LeagueHierarchy:
        modelBuilder.Entity<LeagueHierarchy>()
           .HasOne(lh => lh.Parent)
           .WithMany(lh => lh.Children)
           .HasForeignKey(lh => lh.ParentId);

        // Note: EF Core is smart and can infer many relationships by convention
        // (e.g., based on property names like 'LeagueId' and navigation properties).
        // However, explicit configuration in this method is best practice for clarity
        // and for defining complex rules like unique constraints.
    }
}