using System;
using Tarefeiro.Domain.Entities.Status;

namespace Tarefeiro.Domain.RepositoryInterface.Status;

public interface IStatusRepository
{
    Task<StatusEntity?> GetStatusByIdAsync(int id);
    Task<IEnumerable<StatusEntity>> GetStatusAsync();
    Task<bool> CreateStatusAsync(StatusEntity status);
    Task<bool> UpdateStatusAsync(StatusEntity status);
    Task<bool> DeleteStatusByIdAsync(int id);
}
