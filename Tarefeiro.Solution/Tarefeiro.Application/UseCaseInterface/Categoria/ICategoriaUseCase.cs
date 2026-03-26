using System;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Categoria;

namespace Tarefeiro.Application.UseCaseInterface.Categoria;

public interface ICategoriaUseCase
{
    Task<ServiceResponse<CategoriaDto>> GetCategoriaByIdAsync(int id);
    Task<ServiceResponse<IEnumerable<CategoriaDto>>> GetCategoriasAsync();
    Task<ServiceResponse<bool>> CreateCategoriaAsync(CreateCategoriaDto create);
    Task<ServiceResponse<bool>> UpdateCategoriaAsync(UpdateCategoriaDto update);
    Task<ServiceResponse<bool>> DeleteCategoriaByIdAsync(int id);
}
