namespace Lib.Classes.Dtos.Agenda;

public record AgendaUpdateDto
{
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime? Dia { get; set; }
    public int? CategoriaId { get; set; }
    public int? IntervaloId { get; set; }
}