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

        builder.HasOne(t => t.Status)
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired();

        builder.HasOne(t => t.Categoria)
               .WithMany()
               .HasForeignKey(t => t.CategoriaId)
               .IsRequired();

        builder.Property(t => t.Comentario).IsRequired().HasMaxLength(20);
    }
}
