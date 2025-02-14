﻿// <auto-generated />
using System;
using AgendaApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaApp.Migrations
{
    [DbContext(typeof(AgendaContext))]
    partial class AgendaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Lib.Classes.Entities.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("IntervaloId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("IntervaloId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("Lib.Classes.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Lib.Classes.Entities.Intervalo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comeco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Intervalos");
                });

            modelBuilder.Entity("Lib.Classes.Entities.Agenda", b =>
                {
                    b.HasOne("Lib.Classes.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Lib.Classes.Entities.Intervalo", "Intervalo")
                        .WithMany()
                        .HasForeignKey("IntervaloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Intervalo");
                });
#pragma warning restore 612, 618
        }
    }
}
