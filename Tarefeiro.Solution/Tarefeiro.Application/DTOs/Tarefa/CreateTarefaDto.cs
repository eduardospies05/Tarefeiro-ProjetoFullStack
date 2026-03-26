using System;

namespace Tarefeiro.Application.DTOs.Tarefa;

public class CreateTarefaDto
{
    public int StatusId { get; set; }
    public int CategoriaId { get; set; }
    public required string Comentario { get; set; }
}
