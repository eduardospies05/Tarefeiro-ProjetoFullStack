
using Serilog;
using Tarefeiro.Application.Service;
using Tarefeiro.Infrastructure.Middleware;
using Tarefeiro.Infrastructure.Service;

namespace Tarefeiro.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string originName = "MyAllowSpecificOrigins";
        // Add services to the container.

        builder.Services.InfrastructureService(builder.Configuration, originName)
                        .ApplicationService();
        builder.StartSerilog();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<GlobalException>();
        app.UseCors(originName);
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
