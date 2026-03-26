using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Tarefeiro.Application.Mapping.Categoria;
using Tarefeiro.Application.Mapping.Status;

namespace Tarefeiro.Application.Service;

public static class ServiceContainer
{
    public static IServiceCollection ApplicationService(this IServiceCollection service)
    {
        service.AddAutoMapper(cfg =>
        {
           cfg.AddProfile<CategoriaMapper>();
           cfg.AddProfile<StatusMapper>();
        }, typeof(ServiceContainer).Assembly);
        service.AddFluentValidationAutoValidation();
        service.AddFluentValidationClientsideAdapters();
        service.AddValidatorsFromAssembly(typeof(ServiceContainer).Assembly);
        return service;
    }
}