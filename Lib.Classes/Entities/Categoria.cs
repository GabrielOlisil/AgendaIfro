using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    [Required]
    public string Label { get; set; }
}