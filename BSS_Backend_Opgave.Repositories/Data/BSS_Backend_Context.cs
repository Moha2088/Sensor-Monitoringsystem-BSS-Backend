using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

public class BSS_Backend_Context : DbContext
{
    public BSS_Backend_Context(DbContextOptions<BSS_Backend_Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Applies all the EntityTypeConfigurations from the same assembly as UserEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
    }

    public DbSet<User> User { get; set; } = default!;

    public DbSet<Sensor> Sensor { get; set; } = default!;
    
    public DbSet<Organisation> Organisation { get; set; } = default!;
    
    public DbSet<EventLog> EventLog { get; set; } = default!;
    
    public DbSet<State> State { get; set; } = default!;
}
