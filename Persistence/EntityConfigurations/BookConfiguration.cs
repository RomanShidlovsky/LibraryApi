using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BookConfiguration : BaseConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);
        builder.Property(b => b.Title).HasMaxLength(100);
        builder.Property(b => b.ISBN).HasMaxLength(13);
        builder.HasAlternateKey(b => b.ISBN);
    }
}