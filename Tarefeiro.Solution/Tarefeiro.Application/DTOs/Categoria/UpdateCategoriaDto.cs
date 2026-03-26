using System;

namespace Tarefeiro.Application.DTOs.Categoria;

public class UpdateCategoriaDto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
}