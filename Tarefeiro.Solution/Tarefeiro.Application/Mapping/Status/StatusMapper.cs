using System;
using AutoMapper;
using Tarefeiro.Application.DTOs.Status;
using Tarefeiro.Domain.Entities.Status;

namespace Tarefeiro.Application.Mapping.Status;

public class StatusMapper : Profile
{
    public StatusMapper()
    {
        CreateMap<StatusEntity, StatusDto>();
        CreateMap<CreateStatusDto, StatusEntity>();
        CreateMap<UpdateStatusDto, StatusEntity>();
    }
}
