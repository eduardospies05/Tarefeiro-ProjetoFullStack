using System;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Status;

namespace Tarefeiro.Application.UseCaseInterface.Status;

public interface IStatusUseCase
{
    Task<ServiceResponse<StatusDto>> GetStatusByIdAsync(int id);
    Task<ServiceResponse<IEnumerable<StatusDto>>> GetStatusAsync();
    Task<ServiceResponse<bool>> CreateStatusAsync(CreateStatusDto create);
    Task<ServiceResponse<bool>> UpdateStatusAsync(UpdateStatusDto update);
    Task<ServiceResponse<bool>> DeleteStatusByIdAsync(int id);
}
