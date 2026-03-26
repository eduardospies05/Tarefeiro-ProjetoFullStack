using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Categoria;

namespace Tarefeiro.Application.Validation.Categoria;

public class UpdateCategoriaValidation : AbstractValidator<UpdateCategoriaDto>
{
    public UpdateCategoriaValidation()
    {
        RuleFor(u => u.Id).NotEmpty().GreaterThan(0);
        RuleFor(u => u.Nome).NotEmpty().MaximumLength(20);
    }
}
