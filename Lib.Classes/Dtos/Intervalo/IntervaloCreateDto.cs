using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Dtos.Intervalo;

public class IntervaloCreateDto
{
    [Required] public string Label { get; set; }
    [Required] public string Comeco { get; set; }
    [Required] public string Fim { get; set; }
}