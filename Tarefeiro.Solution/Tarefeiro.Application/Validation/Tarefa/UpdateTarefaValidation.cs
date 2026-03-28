using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Tarefa;

namespace Tarefeiro.Application.Validation.Tarefa;

public class UpdateTarefaValidation : AbstractValidator<UpdateTarefaDto>
{
    public UpdateTarefaValidation()
    {
        RuleFor(c => c.Id).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(c => c.StatusId).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(c => c.CategoriaId).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(c => c.Comentario).NotEmpty().MaximumLength(20);
    }
}
