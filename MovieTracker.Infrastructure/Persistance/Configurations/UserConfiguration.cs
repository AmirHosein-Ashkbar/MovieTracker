using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTracker.Domain.Entities;

namespace MovieTracker.Infrastructure.Persistance.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Username)
           .IsUnique()
           .HasFilter("[IsDeleted] = 0");

        builder.HasIndex(x => x.PhoneNumber)
               .IsUnique()
               .HasFilter("[IsDeleted] = 0");

        builder.HasIndex(x => x.Email)
               .IsUnique()
               .HasFilter("[IsDeleted] = 0");

        builder.Property(x => x.Username).HasMaxLength(30);
        builder.Property(x => x.Password).HasMaxLength(30);

        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);



        builder.HasMany(x => x.Likes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

    }
}
