using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Agenda;

public class AgendaCreateDto
{
    [Required] public string Titulo { get; set; }
    [Required] public string Descricao { get; set; }
    [Required] public DateTime Dia { get; set; }
    [Required] public Guid IntervaloId { get; set; }
    [Required] public Guid CategoriaId { get; set; }
}