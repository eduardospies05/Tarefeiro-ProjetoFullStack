using System;
using AutoMapper;
using Tarefeiro.Application.DTOs.Tarefa;
using Tarefeiro.Domain.Entities.Tarefa;

namespace Tarefeiro.Application.Mapping.Tarefa;

public class TarefaMapper : Profile
{
    public TarefaMapper()
    {
        CreateMap<TarefaEntity, TarefaDto>().ForMember(m => m.Status, opt => opt.MapFrom(src => src.Status.Nome))
                                            .ForMember(m => m.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome));

        CreateMap<CreateTarefaDto, TarefaEntity>();
        CreateMap<UpdateTarefaDto, TarefaEntity>();
    }
}
