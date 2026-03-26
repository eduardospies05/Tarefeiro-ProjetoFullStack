using System;

namespace Tarefeiro.Application.DTOs.Tarefa;

public class UpdateTarefaDto
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int CategoriaId { get; set; }
    public required string Comentario { get; set; }
}
