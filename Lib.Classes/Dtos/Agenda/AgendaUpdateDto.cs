namespace Lib.Classes.Dtos.Agenda;

public class AgendaUpdateDto
{
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime? Dia { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? IntervaloId { get; set; }
}