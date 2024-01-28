﻿using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IBaseEntity 
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(b => b.DateCreated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}