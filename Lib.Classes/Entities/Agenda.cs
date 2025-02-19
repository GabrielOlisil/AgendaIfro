using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Agenda
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Dia { get; set; }
    public Intervalo Intervalo { get; set; }
    public int IntervaloId { get; set; }
    public Categoria? Categoria { get; set; }
}