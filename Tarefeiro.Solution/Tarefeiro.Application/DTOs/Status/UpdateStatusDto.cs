using System;

namespace Tarefeiro.Application.DTOs.Status;

public class UpdateStatusDto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
}
