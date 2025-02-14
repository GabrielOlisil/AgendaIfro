using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Categoria;

public record CategoriaCreateDto
{
    [Required]
    public string? Label { get; set; }
}