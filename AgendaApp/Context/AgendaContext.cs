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
        optionsBuilder.UseMySql(configuration["Database:ConnectionStrings:MariaDB"],
            new MariaDbServerVersion(configuration["Database:ServerVersion"]));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agenda>(e =>
        {
            e.Property(a => a.Dia)
                .IsRequired()
                .HasColumnType("DATE");

            e.HasOne(a => a.Intervalo)
                .WithOne()
                .HasForeignKey<Agenda>(a => a.IntervaloId)
                .IsRequired();

            e.HasIndex(a => a.Dia)
                .HasDatabaseName("IX_Agenda_Dia");
        });

        modelBuilder.Entity<Categoria>(e => { e.Property(a => a.Label).IsRequired(); });

        modelBuilder.Entity<Intervalo>(e =>
        {
            e.Property(a => a.Label).IsRequired();
            e.Property(a => a.Comeco).IsRequired();
            e.HasIndex(a => a.IndexAula)
                .HasDatabaseName("IX_Intervalo_IndexAula").IsUnique();
        });

        modelBuilder.Entity<Intervalo>().HasData(
            // Periodo Manhã
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "08:05",
                Label = "1º Aula",
                IndexAula = 0
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "08:55",
                Label = "2º Aula",
                IndexAula = 1
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "10:00",
                Label = "3º Aula",
                IndexAula = 2
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "10:5",
                Label = "4º Aula",
                IndexAula = 3
            },
            // Periodo Tarde
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "13:05",
                Label = "1º Aula",
                IndexAula = 4
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "13:55",
                Label = "2º Aula",
                IndexAula = 5
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "14:45",
                Label = "3º Aula",
                IndexAula = 6
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "15:50",
                Label = "4º Aula",
                IndexAula = 7
            },
            new Intervalo
            {
                Id =Guid.NewGuid(),
                Comeco = "16:40",
                Label = "5º Aula",
                IndexAula = 8
            },
            // Aulas Noturnas
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "19:00",
                Label = "1º Aula",
                IndexAula = 9
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "19:50",
                Label = "2º Aula",
                IndexAula = 10
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "22:55",
                Label = "3º Aula",
                IndexAula = 11
            },
            new Intervalo
            {
                Id = Guid.NewGuid(),
                Comeco = "21:45",
                Label = "4º Aula",
                IndexAula = 12
            }
        );
    }
}