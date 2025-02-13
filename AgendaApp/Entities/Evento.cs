namespace AgendaApp.Entities;

public class Evento
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public DateTime Dia { get; set; }
    public Intervalo Intervalo { get; set; }
}