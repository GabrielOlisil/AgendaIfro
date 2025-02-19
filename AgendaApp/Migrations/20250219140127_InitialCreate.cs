using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgendaApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Intervalos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IndexAula = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comeco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervalos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dia = table.Column<DateTime>(type: "DATE", nullable: false),
                    IntervaloId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Intervalos_IntervaloId",
                        column: x => x.IntervaloId,
                        principalTable: "Intervalos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Intervalos",
                columns: new[] { "Id", "Comeco", "IndexAula", "Label" },
                values: new object[,]
                {
                    { 1, "08:05", 0, "1º Aula" },
                    { 2, "08:55", 1, "2º Aula" },
                    { 3, "10:00", 2, "3º Aula" },
                    { 4, "10:50", 3, "4º Aula" },
                    { 5, "13:05", 4, "1º Aula" },
                    { 6, "13:55", 5, "2º Aula" },
                    { 7, "14:45", 6, "3º Aula" },
                    { 8, "15:50", 7, "4º Aula" },
                    { 9, "16:40", 8, "5º Aula" },
                    { 10, "19:00", 9, "1º Aula" },
                    { 11, "19:50", 10, "2º Aula" },
                    { 12, "22:55", 11, "3º Aula" },
                    { 13, "21:45", 12, "4º Aula" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Dia",
                table: "Agendamentos",
                column: "Dia");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_CategoriaId",
                table: "Agendamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_IntervaloId",
                table: "Agendamentos",
                column: "IntervaloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intervalo_IndexAula",
                table: "Intervalos",
                column: "IndexAula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Intervalos");
        }
    }
}
