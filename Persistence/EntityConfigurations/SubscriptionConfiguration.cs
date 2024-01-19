using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SubscriptionConfiguration : BaseConfiguration<Subscription>
{
    public override void Configure(EntityTypeBuilder<Subscription> builder)
    {
        base.Configure(builder);
        builder.ToTable(t => t.HasCheckConstraint("CK_StartBeforeFinish", "[Start] < [Finish]"));
        builder.Property(s => s.IsActive).HasDefaultValue(false);
    }
}