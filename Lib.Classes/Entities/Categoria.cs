using System.ComponentModel.DataAnnotations;

namespace Lib.Classes.Entities;

public class Categoria
{
    public Guid Id { get; set; }
    public string Label { get; set; }
}