using System;
using FluentValidation;
using Tarefeiro.Application.DTOs.Status;

namespace Tarefeiro.Application.Validation.Status;

public class UpdateStatusValidation : AbstractValidator<UpdateStatusDto>
{
    public UpdateStatusValidation()
    {
        RuleFor(u => u.Id).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(u => u.Nome).NotEmpty().MaximumLength(20);
    }
}
