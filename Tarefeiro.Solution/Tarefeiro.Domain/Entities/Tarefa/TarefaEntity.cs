using System;
using Tarefeiro.Domain.Entities.Categoria;
using Tarefeiro.Domain.Entities.Status;

namespace Tarefeiro.Domain.Entities.Tarefa;

public class TarefaEntity
{
    public int Id { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public int StatusId { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaEntity Categoria { get; set; } = null!;
    public required string Comentario { get; set; }
}
