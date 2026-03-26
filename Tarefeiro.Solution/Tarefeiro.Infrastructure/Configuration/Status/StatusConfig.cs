using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefeiro.Domain.Entities.Status;

namespace Tarefeiro.Infrastructure.Configuration.Status;

public class StatusConfig : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome).IsRequired().HasMaxLength(20);
    }
}
