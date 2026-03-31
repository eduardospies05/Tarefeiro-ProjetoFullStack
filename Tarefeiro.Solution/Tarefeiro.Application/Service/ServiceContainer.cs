using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Tarefeiro.Application.Mapping.Categoria;
using Tarefeiro.Application.Mapping.Status;
using Tarefeiro.Application.Mapping.Tarefa;

namespace Tarefeiro.Application.Service;

public static class ServiceContainer
{
    public static IServiceCollection ApplicationService(this IServiceCollection service)
    {
        service.AddSerilog();
        service.AddAutoMapper(cfg =>
        {
           cfg.AddProfile<CategoriaMapper>();
           cfg.AddProfile<StatusMapper>();
           cfg.AddProfile<TarefaMapper>();
        }, typeof(ServiceContainer).Assembly);
        service.AddFluentValidationAutoValidation();
        service.AddFluentValidationClientsideAdapters();
        service.AddValidatorsFromAssembly(typeof(ServiceContainer).Assembly);
        return service;
    }

    public static WebApplicationBuilder StartSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, service, config) =>
        {
           config.MinimumLevel.Information()
                 .WriteTo.Debug()
                 .WriteTo.Console()
                 .WriteTo.File(
                    path: "tarefeiro-log",
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                    rollingInterval: RollingInterval.Day
                 ).Enrich.FromLogContext();
        });
        return builder;
    }
}