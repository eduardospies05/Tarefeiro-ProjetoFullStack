using System;
using Tarefeiro.Domain.Entities.Categoria;

namespace Tarefeiro.Domain.RepositoryInterface.Categoria;

public interface ICategoriaRepository
{
    Task<CategoriaEntity?> GetCategoriaByIdAsync(int id);
    Task<IEnumerable<CategoriaEntity>> GetCategoriasAsync();
    Task<bool> CreateCategoriaAsync(CategoriaEntity categoria);
    Task<bool> UpdateCategoriaAsync(CategoriaEntity categoria);
    Task<bool> DeleteCategoriaAsync(int id);
}