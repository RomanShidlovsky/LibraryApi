using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RoleConfiguration : BaseConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);
        builder.Property(r => r.Name).HasMaxLength(15);
        builder.HasAlternateKey(r => r.Name);
        builder.Property(r => r.ConcurrencyStamp).HasDefaultValue(Guid.NewGuid().ToString());
    }
}