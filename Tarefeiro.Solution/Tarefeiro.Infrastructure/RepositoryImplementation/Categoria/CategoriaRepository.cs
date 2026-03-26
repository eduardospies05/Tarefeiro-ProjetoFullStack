using System;
using Microsoft.EntityFrameworkCore;
using Tarefeiro.Domain.Entities.Categoria;
using Tarefeiro.Domain.RepositoryInterface.Categoria;
using Tarefeiro.Infrastructure.Data;

namespace Tarefeiro.Infrastructure.RepositoryImplementation.Categoria;

public class CategoriaRepository(AppDbContext context) : ICategoriaRepository
{
    public async Task<bool> CreateCategoriaAsync(CategoriaEntity categoria)
    {
        await context.Categorias.AddAsync(categoria);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteCategoriaAsync(int id)
    {
        return await context.Categorias.Where(c => c.Id ==  id).ExecuteDeleteAsync() > 0;
    }

    public async Task<CategoriaEntity?> GetCategoriaByIdAsync(int id)
    {
        return await context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CategoriaEntity>> GetCategoriasAsync()
    {
        return await context.Categorias.AsNoTracking().ToListAsync();
    }

    public async Task<bool> UpdateCategoriaAsync(CategoriaEntity categoria)
    {
        return await context.Categorias.Where(c => c.Id == categoria.Id)
                                       .ExecuteUpdateAsync(setter => setter
                                       .SetProperty(c => c.Nome, categoria.Nome)) > 0;
    }
}
