using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTracker.Domain.Entities;

namespace MovieTracker.Infrastructure.Persistance.Configurations;
public class OtpConfiguration : IEntityTypeConfiguration<Otp>
{
    public void Configure(EntityTypeBuilder<Otp> builder)
    {
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Code).HasMaxLength(10);
    }
}
