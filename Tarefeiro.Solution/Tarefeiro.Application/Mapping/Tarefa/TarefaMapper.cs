using System;
using AutoMapper;
using Tarefeiro.Application.DTOs.Tarefa;
using Tarefeiro.Domain.Entities.Tarefa;

namespace Tarefeiro.Application.Mapping.Tarefa;

public class TarefaMapper : Profile
{
    public TarefaMapper()
    {
        CreateMap<TarefaEntity, TarefaDto>()
            .ForMember(src => src.Status, opt => opt.MapFrom(m => new ShortStatusDto(m.Status.Id, m.Status.Nome)))
            .ForMember(src => src.Categoria, opt => opt.MapFrom(m => new ShortCategoriaDto(m.Categoria.Id, m.Categoria.Nome)));

        CreateMap<CreateTarefaDto, TarefaEntity>();
        CreateMap<UpdateTarefaDto, TarefaEntity>();
    }
}
