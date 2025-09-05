using Microsoft.EntityFrameworkCore;
using MovieTracker.Domain.Entities;
using MovieTracker.Infrastructure.Persistance.Configurations;
using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Infrastructure.Persistance.Contexts;
public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<string>().HaveMaxLength(256);

        builder.Properties<DateTime>().HaveColumnType("datetime2");
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);

    }

    public DbSet<Movie> Movies { get; set; }
        
}
