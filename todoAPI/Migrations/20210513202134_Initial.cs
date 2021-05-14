using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace todoAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completado = table.Column<bool>(type: "bit", nullable: false),
                    Prazo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Completado", "Descricao", "Prazo", "Prioridade" },
                values: new object[,]
                {
                    { 1, false, "Analisar Requisitos", new DateTime(2021, 5, 13, 17, 21, 34, 296, DateTimeKind.Local).AddTicks(5407), "Alta" },
                    { 2, false, "Criar o Model", new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8723), "Alta" },
                    { 3, false, "Criar e implementar o Controller", new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8832), "Alta" },
                    { 4, false, "Criar a Interface Front End em Angular", new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8836), "Alta" },
                    { 5, false, "Terminar e Testar a Aplicação", new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8838), "Alta" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
