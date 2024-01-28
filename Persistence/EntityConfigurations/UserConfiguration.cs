using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.UserName).HasMaxLength(50);
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.HasAlternateKey(u => u.UserName);
    }
}