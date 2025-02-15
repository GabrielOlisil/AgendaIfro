using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Intervalo
{
    public Guid Id { get; set; }
    public int IndexAula { get; set; }
    public string Label { get; set; }
    public string Comeco { get; set; }
    
}