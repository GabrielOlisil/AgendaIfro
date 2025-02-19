using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Agenda;

public record AgendaCreateDto
{
    [Required] public string Titulo { get; set; }
    [Required] public string Descricao { get; set; }
    [Required] public DateTime Dia { get; set; }
    [Required] public int? IntervaloId { get; set; }
    public int? CategoriaId { get; set; }
} 