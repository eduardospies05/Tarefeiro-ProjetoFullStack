using System;

namespace Tarefeiro.Application.DTOs.Tarefa;
public record class ShortStatusDto(int id, string Status);
public record class ShortCategoriaDto(int id, string Categoria);
public class TarefaDto
{
    public int Id { get; set; }
    public ShortStatusDto Status { get; set; } = null!;
    public ShortCategoriaDto Categoria { get; set; } = null!;
    public string Comentario { get; set; } = string.Empty;
}
