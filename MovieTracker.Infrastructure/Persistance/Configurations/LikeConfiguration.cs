using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTracker.Domain.Entities;

namespace MovieTracker.Infrastructure.Persistance.Configurations;
public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(x => x.Id);
        //builder.Property(x => x.Id).UseIdentityColumn();

        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId);

        builder.HasOne(l => l.Movie)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.MovieId);

    }
}
