using System;
using Microsoft.EntityFrameworkCore;
using Tarefeiro.Domain.Entities.Tarefa;
using Tarefeiro.Domain.RepositoryInterface.Tarefa;
using Tarefeiro.Infrastructure.Data;

namespace Tarefeiro.Infrastructure.RepositoryImplementation.Tarefa;

public class TarefaRepository(AppDbContext context) : ITarefaRepository
{
    public async Task<bool> CreateTarefaAsync(TarefaEntity tarefa)
    {
        await context.Tarefas.AddAsync(tarefa);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTarefaByIdAsync(int id)
    {
        return await context.Tarefas.Where(t => t.Id == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<TarefaEntity?> GetTarefaByIdAsync(int id)
    {
        return await context.Tarefas.AsNoTracking()
                                    .Include(t => t.Status)
                                    .Include(t => t.Categoria)
                                    .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TarefaEntity>> GetTarefasAsync()
    {
        return await context.Tarefas.AsNoTracking()
                                    .Include(t => t.Status)
                                    .Include(t => t.Categoria)
                                    .ToListAsync();
    }

    public async Task<bool> UpdateTarefaAsync(TarefaEntity tarefa)
    {
        return await context.Tarefas.Where(t => t.Id == tarefa.Id).ExecuteUpdateAsync(setter => setter
                                    .SetProperty(t => t.StatusId, tarefa.StatusId)
                                    .SetProperty(t => t.CategoriaId, tarefa.CategoriaId)
                                    .SetProperty(t => t.Comentario, tarefa.Comentario)) > 0;
    }
}
