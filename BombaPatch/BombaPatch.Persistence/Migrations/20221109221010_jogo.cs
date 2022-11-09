using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaPatch.Persistence.Migrations
{
    public partial class jogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JogosId",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JogosId",
                table: "Estadios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JogosId",
                table: "Arbitros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    data = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GruposSelecoes_JogosId",
                table: "GruposSelecoes",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Estadios_JogosId",
                table: "Estadios",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_JogosId",
                table: "Arbitros",
                column: "JogosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbitros_Jogos_JogosId",
                table: "Arbitros",
                column: "JogosId",
                principalTable: "Jogos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estadios_Jogos_JogosId",
                table: "Estadios",
                column: "JogosId",
                principalTable: "Jogos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GruposSelecoes_Jogos_JogosId",
                table: "GruposSelecoes",
                column: "JogosId",
                principalTable: "Jogos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbitros_Jogos_JogosId",
                table: "Arbitros");

            migrationBuilder.DropForeignKey(
                name: "FK_Estadios_Jogos_JogosId",
                table: "Estadios");

            migrationBuilder.DropForeignKey(
                name: "FK_GruposSelecoes_Jogos_JogosId",
                table: "GruposSelecoes");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_GruposSelecoes_JogosId",
                table: "GruposSelecoes");

            migrationBuilder.DropIndex(
                name: "IX_Estadios_JogosId",
                table: "Estadios");

            migrationBuilder.DropIndex(
                name: "IX_Arbitros_JogosId",
                table: "Arbitros");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "Estadios");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "Arbitros");
        }
    }
}
