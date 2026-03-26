using System;
using Microsoft.EntityFrameworkCore;
using Tarefeiro.Domain.Entities.Categoria;
using Tarefeiro.Domain.Entities.Status;
using Tarefeiro.Domain.Entities.Tarefa;

namespace Tarefeiro.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CategoriaEntity> Categorias { get; set; }
    public DbSet<TarefaEntity> Tarefas { get; set; }
    public DbSet<StatusEntity> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
