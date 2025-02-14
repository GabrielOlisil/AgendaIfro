using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Intervalo
{
    public Guid Id { get; set; }
    [Required]
    public string Label { get; set; }
    [Required]
    public string Comeco { get; set; }
    [Required]
    public string Fim { get; set; }
    
}