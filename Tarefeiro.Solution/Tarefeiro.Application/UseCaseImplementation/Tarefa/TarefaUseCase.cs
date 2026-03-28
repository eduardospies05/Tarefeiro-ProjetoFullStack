using System;
using AutoMapper;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Tarefa;
using Tarefeiro.Application.UseCaseInterface.Tarefa;
using Tarefeiro.Domain.Entities.Tarefa;
using Tarefeiro.Domain.RepositoryInterface.Tarefa;

namespace Tarefeiro.Application.UseCaseImplementation.Tarefa;

public class TarefaUseCase(ITarefaRepository repository, IMapper map) : ITarefaUseCase
{
    public async Task<ServiceResponse<bool>> CreateTarefaAsync(CreateTarefaDto create)
    {
        bool success = await repository.CreateTarefaAsync(map.Map<TarefaEntity>(create));

        if (!success)
            return new(false, "Erro ao criar nova tarefa", false);

        return new(true, "Tarefa criada com sucesso", true);
    }

    public async Task<ServiceResponse<bool>> DeleteTarefaByIdAsync(int id)
    {
        bool success = await repository.DeleteTarefaByIdAsync(id);

        if (!success)
            return new(false, "Erro ao deletar tarefa", false);

        return new(true, "Tarefa deletada com sucesso", true);
    }

    public async Task<ServiceResponse<TarefaDto>> GetTarefaByIdAsync(int id)
    {
        var tarefa = await repository.GetTarefaByIdAsync(id);

        if(tarefa is null)
            return new(null, "Tarefa não encontrada", false);

        return new(map.Map<TarefaDto>(tarefa), "Tarefa encontrada", true);
    }

    public async Task<ServiceResponse<IEnumerable<TarefaDto>>> GetTarefasAsync()
    {
        var tarefas = map.Map<IEnumerable<TarefaDto>>(await repository.GetTarefasAsync());

        return new(tarefas, "Tarefas listadas", true);
    }

    public async Task<ServiceResponse<bool>> UpdateTarefaAsync(UpdateTarefaDto update)
    {
        bool success = await repository.UpdateTarefaAsync(map.Map<TarefaEntity>(update));

        if (!success)
            return new(false, "Erro ao atualizar tarefa", false);

        return new(true, "Tarefa atualizada com sucesso", true);
    }
}
