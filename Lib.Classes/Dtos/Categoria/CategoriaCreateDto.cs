using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Categoria;

public class CategoriaCreateDto
{
    [Required]
    public string? Label { get; set; }
}