using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Categoria;

namespace Tarefeiro.Application.Validation.Categoria;

public class CreateCategoriaValidation : AbstractValidator<CreateCategoriaDto>
{
    public CreateCategoriaValidation()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(20);
    }
}
