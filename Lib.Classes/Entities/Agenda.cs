using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Agenda
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    [Required]
    public DateTime Dia { get; set; }
    [Required]
    public Intervalo Intervalo { get; set; }

    public Categoria? Categoria { get; set; }
}