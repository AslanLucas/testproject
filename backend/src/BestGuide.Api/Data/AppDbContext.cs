using BestGuide.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Guide> Guides => Set<Guide>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Lädt alle IEntityTypeConfiguration<T> aus Data/Configurations/
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
