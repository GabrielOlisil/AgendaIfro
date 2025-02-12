using AgendaApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Context;

public class AgendaContext(IConfiguration configuration) : DbContext
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Intervalo> Intervalos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(configuration["Database:ConnectionStrings:MariaDB"], new MariaDbServerVersion(configuration["Database:ServerVersion"]));
    }
}