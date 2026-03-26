using System;

namespace Tarefeiro.Domain.Entities.Categoria;

public class CategoriaEntity
{
    public int Id { get; set; }
    public required string Nome { get; set; }
}
