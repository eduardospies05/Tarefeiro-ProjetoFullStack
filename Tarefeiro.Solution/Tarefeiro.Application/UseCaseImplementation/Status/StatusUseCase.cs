using System;
using AutoMapper;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Status;
using Tarefeiro.Application.UseCaseInterface.Status;
using Tarefeiro.Domain.Entities.Status;
using Tarefeiro.Domain.RepositoryInterface.Status;

namespace Tarefeiro.Application.UseCaseImplementation.Status;

public class StatusUseCase(IStatusRepository repository, IMapper map) : IStatusUseCase
{
    public async Task<ServiceResponse<bool>> CreateStatusAsync(CreateStatusDto create)
    {
        bool success = await repository.CreateStatusAsync(map.Map<StatusEntity>(create));

        if(!success)
            return new(false, "Erro ao criar novo status", false);

        return new(true, "Status criado com sucesso", true);
    }

    public async Task<ServiceResponse<bool>> DeleteStatusByIdAsync(int id)
    {
        bool success = await repository.DeleteStatusByIdAsync(id);

        if(!success)
            return new(false, "Erro ao deletar status", false);

        return new(true, "Status deletado com sucesso", true);
    }

    public async Task<ServiceResponse<IEnumerable<StatusDto>>> GetStatusAsync()
    {
        var list = map.Map<IEnumerable<StatusDto>>(await repository.GetStatusAsync());

        return new(list, "Status listados", true);
    }

    public async Task<ServiceResponse<StatusDto>> GetStatusByIdAsync(int id)
    {
        var status = await repository.GetStatusByIdAsync(id);

        if(status is null)
            return new(null, "Status não encontrado", true);

        return new(map.Map<StatusDto>(status), "Status encontrado", true);
    }

    public async Task<ServiceResponse<bool>> UpdateStatusAsync(UpdateStatusDto update)
    {
        bool success = await repository.UpdateStatusAsync(map.Map<StatusEntity>(update));

        if(!success)
            return new(false, "Erro ao atualizar status", false);

        return new(true, "Status atualizado com sucesso", true);
    }
}
