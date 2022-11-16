using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaPatch.Persistence.Migrations
{
    public partial class partida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selecoes_GruposSelecoes_GrupoId",
                table: "Selecoes");

            migrationBuilder.DropIndex(
                name: "IX_Selecoes_GrupoId",
                table: "Selecoes");

            migrationBuilder.DropColumn(
                name: "GrupoIdentificador",
                table: "Selecoes");

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    selecoes = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.AddColumn<int>(
                name: "GrupoIdentificador",
                table: "Selecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Selecoes_GrupoId",
                table: "Selecoes",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Selecoes_GruposSelecoes_GrupoId",
                table: "Selecoes",
                column: "GrupoId",
                principalTable: "GruposSelecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
