using System;
using AutoMapper;
using Tarefeiro.Application.DTOs.Categoria;
using Tarefeiro.Domain.Entities.Categoria;

namespace Tarefeiro.Application.Mapping.Categoria;

public class CategoriaMapper : Profile
{
    public CategoriaMapper()
    {
        CreateMap<CategoriaEntity,    CategoriaDto>();
        CreateMap<CreateCategoriaDto, CategoriaEntity>();
        CreateMap<UpdateCategoriaDto, CategoriaEntity>();
    }
}
