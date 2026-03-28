using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Tarefa;

namespace Tarefeiro.Application.Validation.Tarefa;

public class CreateTarefaValidation : AbstractValidator<CreateTarefaDto>
{
    public CreateTarefaValidation()
    {
        RuleFor(c => c.StatusId).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(c => c.CategoriaId).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(c => c.Comentario).NotEmpty().MaximumLength(20);
    }
}
