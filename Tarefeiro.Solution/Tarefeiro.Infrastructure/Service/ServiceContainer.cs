using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarefeiro.Application.UseCaseImplementation.Categoria;
using Tarefeiro.Application.UseCaseImplementation.Status;
using Tarefeiro.Application.UseCaseImplementation.Tarefa;
using Tarefeiro.Application.UseCaseInterface.Categoria;
using Tarefeiro.Application.UseCaseInterface.Status;
using Tarefeiro.Application.UseCaseInterface.Tarefa;
using Tarefeiro.Domain.RepositoryInterface.Categoria;
using Tarefeiro.Domain.RepositoryInterface.Status;
using Tarefeiro.Domain.RepositoryInterface.Tarefa;
using Tarefeiro.Infrastructure.Data;
using Tarefeiro.Infrastructure.RepositoryImplementation.Categoria;
using Tarefeiro.Infrastructure.RepositoryImplementation.Status;
using Tarefeiro.Infrastructure.RepositoryImplementation.Tarefa;

namespace Tarefeiro.Infrastructure.Service;

public static class ServiceContainer
{
    public static IServiceCollection InfrastructureService(this IServiceCollection service, IConfiguration config, string originName)
    {
        string con = config.GetConnectionString("DefaultConnection") ??
                        throw new InvalidOperationException("Conexao nao encontrada");

        service.AddDbContext<AppDbContext>(options =>
        {
           options.UseMySql(con, ServerVersion.AutoDetect(con)); 
        });

        service.AddScoped<ICategoriaRepository, CategoriaRepository>();
        service.AddScoped<ICategoriaUseCase, CategoriaUseCase>();
        service.AddScoped<IStatusUseCase, StatusUseCase>();
        service.AddScoped<IStatusRepository, StatusRepository>();
        service.AddScoped<ITarefaRepository, TarefaRepository>();
        service.AddScoped<ITarefaUseCase, TarefaUseCase>();


        service.AddCors(options =>
        {
           options.AddPolicy(
                name: originName,
                builder => builder.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
            );
        });
        return service;
    }
}
