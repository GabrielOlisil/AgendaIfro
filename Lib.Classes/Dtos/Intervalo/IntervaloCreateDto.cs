using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Intervalo;

public record IntervaloCreateDto
{
    [Required] public string Label { get; set; }
    [Required] public string Comeco { get; set; }
}