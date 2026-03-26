using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefeiro.Domain.Entities.Categoria;

namespace Tarefeiro.Infrastructure.Configuration.Categoria;

public class CategoriaConfig : IEntityTypeConfiguration<CategoriaEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
    }
}