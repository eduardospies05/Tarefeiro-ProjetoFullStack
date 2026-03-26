using System;
using Tarefeiro.Domain.Entities.Categoria;

namespace Tarefeiro.Domain.Entities.Tarefa;

public class TarefaEntity
{
    public int Id { get; set; }
    public required string Status { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaEntity Categoria { get; set; } = null!;
    public required string Comentario { get; set; }
}
