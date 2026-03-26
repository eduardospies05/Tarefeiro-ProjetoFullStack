using System;
using AutoMapper;
using Tarefeiro.Application.AppResponse;
using Tarefeiro.Application.DTOs.Categoria;
using Tarefeiro.Application.UseCaseInterface.Categoria;
using Tarefeiro.Domain.Entities.Categoria;
using Tarefeiro.Domain.RepositoryInterface.Categoria;

namespace Tarefeiro.Application.UseCaseImplementation.Categoria;

public class CategoriaUseCase(ICategoriaRepository repository, IMapper map) : ICategoriaUseCase
{
    public async Task<ServiceResponse<bool>> CreateCategoriaAsync(CreateCategoriaDto create)
    {
        bool success = await repository.CreateCategoriaAsync(map.Map<CategoriaEntity>(create));

        if(!success)
            return new(false, "Erro ao criar categoria", false);

        return new(true, "Categoria criada com sucesso", true);
    }

    public async Task<ServiceResponse<bool>> DeleteCategoriaByIdAsync(int id)
    {
        bool success = await repository.DeleteCategoriaAsync(id);

        if(!success)
            return new(false, "Erro ao deletar categoria", false);

        return new(true, "Categoria deletada com sucesso", true);
    }

    public async Task<ServiceResponse<CategoriaDto>> GetCategoriaByIdAsync(int id)
    {
        var categoria = await repository.GetCategoriaByIdAsync(id);

        if(categoria is null)
            return new(null, "Categoria não encontrada", false);

        return new(map.Map<CategoriaDto>(categoria), "Categoria encontrada", true);
    }

    public async Task<ServiceResponse<IEnumerable<CategoriaDto>>> GetCategoriasAsync()
    {
        var list =  map.Map<IEnumerable<CategoriaDto>>(await repository.GetCategoriasAsync());

        return new(list, "Categorias listadas", true);
    }

    public async Task<ServiceResponse<bool>> UpdateCategoriaAsync(UpdateCategoriaDto update)
    {
        bool success = await repository.UpdateCategoriaAsync(map.Map<CategoriaEntity>(update));

        if(!success)
            return new(false, "Erro ao atualizar categoria", false);

        return new(true, "Categoria atualizada com sucesso", true);
    }
}
