using Microsoft.EntityFrameworkCore;
using MovieTracker.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Infrastructure.Persistance.Contexts;
public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var x = modelBuilder.Entity<Movie>();   
        modelBuilder.Entity<Movie>().Property(x => x.Id)
        base.OnModelCreating(modelBuilder);
    }

    DbSet<Movie>

}
