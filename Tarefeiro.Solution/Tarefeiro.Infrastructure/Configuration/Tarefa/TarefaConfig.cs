using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefeiro.Domain.Entities.Tarefa;

namespace Tarefeiro.Infrastructure.Configuration.Tarefa;

public class TarefaConfig : IEntityTypeConfiguration<TarefaEntity>
{
    public void Configure(EntityTypeBuilder<TarefaEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Status).IsRequired().HasMaxLength(20);

        builder.Property(t => t.Comentario).IsRequired().HasMaxLength(20);
    }
}
