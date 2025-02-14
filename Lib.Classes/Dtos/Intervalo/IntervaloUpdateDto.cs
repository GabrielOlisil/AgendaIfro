namespace Lib.Classes.Dtos.Intervalo;

public record IntervaloUpdateDto
{
    public string? Label { get; set; }
    public string? Comeco { get; set; }
    public string? Fim { get; set; }
}