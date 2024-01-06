using Microsoft.EntityFrameworkCore;
using Teams.Domain.Entities;

namespace Teams.Infrastructure.DAL;

internal sealed class TeamDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Member> Members { get; set; }

    public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
