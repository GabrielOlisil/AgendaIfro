using System;
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dia = table.Column<DateTime>(type: "DATE", nullable: false),
                    IntervaloId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                    { new Guid("319e5fae-20c9-4166-8009-329a9a5dd4d1"), "10:00", 2, "3º Aula" },
                    { new Guid("47afdfbd-b19b-4f64-a491-b12d4a5b6864"), "14:45", 6, "3º Aula" },
                    { new Guid("48353c00-1b14-490c-86c6-d954c58877e7"), "08:05", 0, "1º Aula" },
                    { new Guid("5fd6654a-41d1-4e7e-91e0-b9db388c533b"), "08:55", 1, "2º Aula" },
                    { new Guid("6e503222-a32a-4903-9007-af8ecbab563f"), "19:00", 9, "1º Aula" },
                    { new Guid("8176df7d-e82f-4f60-b2e6-e57f363e3d53"), "15:50", 7, "4º Aula" },
                    { new Guid("9f23cf25-2183-4a7e-8e83-6a5e46cdb847"), "10:5", 3, "4º Aula" },
                    { new Guid("bf837f59-0779-48d9-b5ca-268061248ebb"), "22:55", 11, "3º Aula" },
                    { new Guid("c6c1f321-b3d0-4a65-bc2f-191205f722f2"), "16:40", 8, "5º Aula" },
                    { new Guid("d5aa0deb-ac8f-4c41-9b65-1980ef5c60f4"), "21:45", 12, "4º Aula" },
                    { new Guid("d9ec58f2-9a57-4c35-8695-b47693477b4a"), "13:55", 5, "2º Aula" },
                    { new Guid("ddeb3124-a603-4c58-9a96-3f743ea89d6b"), "13:05", 4, "1º Aula" },
                    { new Guid("fca35fc6-a9c3-4d89-a7a9-81c5058e3198"), "19:50", 10, "2º Aula" }
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
