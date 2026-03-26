using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Status;

namespace Tarefeiro.Application.Validation.Status;

public class CreateStatusValidation : AbstractValidator<CreateStatusDto>
{
    public CreateStatusValidation()
    {
        RuleFor(c => c.Nome).NotEmpty().MaximumLength(20);
    }
}
