using Lib.Classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Context;

public class AgendaContext(IConfiguration configuration) : DbContext
{
    public DbSet<Agenda> Agendamentos { get; set; }
    public DbSet<Intervalo> Intervalos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(configuration["Database:ConnectionStrings:MariaDB"], new MariaDbServerVersion(configuration["Database:ServerVersion"]));
    }
}