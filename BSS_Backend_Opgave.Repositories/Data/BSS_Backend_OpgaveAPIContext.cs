using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BSS_Backend_Opgave.Models;
using BSS_Backend_Opgave.Repositories.EntityTypeConfigurations;

namespace BSS_Backend_Opgave.Repositories.Data;

public class BSS_Backend_OpgaveAPIContext : DbContext
{
    public BSS_Backend_OpgaveAPIContext(DbContextOptions<BSS_Backend_OpgaveAPIContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Applies all the EntityTypeConfigurations from the same assembly as UserEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
    }

    public DbSet<User> User { get; set; } = default!;

    public DbSet<State> State { get; set; } = default!;

    public DbSet<Sensor> Sensor { get; set; } = default!;

    public DbSet<SensorCategory> SensorCategory { get; set; } = default!;

    public DbSet<Organisation> Organisation { get; set; } = default!;

    public DbSet<EventLog> EventLog { get; set; } = default!;

}
