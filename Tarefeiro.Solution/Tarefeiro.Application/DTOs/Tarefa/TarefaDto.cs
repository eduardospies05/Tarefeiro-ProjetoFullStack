using System;

namespace Tarefeiro.Application.DTOs.Tarefa;

public class TarefaDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
}
