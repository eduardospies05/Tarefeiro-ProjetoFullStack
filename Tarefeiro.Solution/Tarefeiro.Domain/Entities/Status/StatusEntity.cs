using System;

namespace Tarefeiro.Domain.Entities.Status;

public class StatusEntity
{
    public int Id { get; set; }
    public required string Nome { get; set; }
}
