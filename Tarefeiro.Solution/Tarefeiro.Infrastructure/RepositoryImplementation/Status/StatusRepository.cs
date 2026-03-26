using System;
using Microsoft.EntityFrameworkCore;
using Tarefeiro.Domain.Entities.Status;
using Tarefeiro.Domain.RepositoryInterface.Status;
using Tarefeiro.Infrastructure.Data;

namespace Tarefeiro.Infrastructure.RepositoryImplementation.Status;

public class StatusRepository(AppDbContext context) : IStatusRepository
{
    public async Task<bool> CreateStatusAsync(StatusEntity status)
    {
        await context.Status.AddAsync(status);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteStatusByIdAsync(int id)
    {
        return await context.Status.Where(s => s.Id == id).ExecuteDeleteAsync() > 0;
    }

    public async Task<IEnumerable<StatusEntity>> GetStatusAsync()
    {
        return await context.Status.AsNoTracking().ToListAsync();
    }

    public async Task<StatusEntity?> GetStatusByIdAsync(int id)
    {
        return await context.Status.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<bool> UpdateStatusAsync(StatusEntity status)
    {
        return await context.Status.Where(s => s.Id == status.Id).ExecuteUpdateAsync(setter => setter
                                   .SetProperty(s => s.Nome, status.Nome)) > 0;
    }
}
