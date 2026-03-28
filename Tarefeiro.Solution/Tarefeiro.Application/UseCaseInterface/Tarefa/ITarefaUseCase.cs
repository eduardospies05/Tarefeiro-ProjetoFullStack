using System;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Tarefa;

namespace Tarefeiro.Application.UseCaseInterface.Tarefa;

public interface ITarefaUseCase
{
    Task<ServiceResponse<TarefaDto>> GetTarefaByIdAsync(int id);
    Task<ServiceResponse<IEnumerable<TarefaDto>>> GetTarefasAsync();
    Task<ServiceResponse<bool>> CreateTarefaAsync(CreateTarefaDto create);
    Task<ServiceResponse<bool>> UpdateTarefaAsync(UpdateTarefaDto update);
    Task<ServiceResponse<bool>> DeleteTarefaByIdAsync(int id);
}
