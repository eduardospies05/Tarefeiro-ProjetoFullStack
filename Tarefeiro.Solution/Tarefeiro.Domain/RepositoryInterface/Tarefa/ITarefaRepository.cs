using System;
using Tarefeiro.Domain.Entities.Tarefa;

namespace Tarefeiro.Domain.RepositoryInterface.Tarefa;

public interface ITarefaRepository
{
    Task<TarefaEntity?> GetTarefaByIdAsync(int id);
    Task<IEnumerable<TarefaEntity>> GetTarefasAsync();
    Task<bool> CreateTarefaAsync(TarefaEntity tarefa);
    Task<bool> UpdateTarefaAsync(TarefaEntity tarefa);
    Task<bool> DeleteTarefaByIdAsync(int id);
}
