using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaPatch.Persistence.Migrations
{
    public partial class classesnovas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelecaoClassificada1",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelecaoClassificada2",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GrupoClassificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GrupoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Posicao = table.Column<int>(type: "INTEGER", nullable: false),
                    Criterio1Pontos = table.Column<int>(type: "INTEGER", nullable: false),
                    Criterio2SaldoGols = table.Column<int>(type: "INTEGER", nullable: false),
                    Criterio3GolsMarcados = table.Column<int>(type: "INTEGER", nullable: false),
                    Criterio4CartoesVermelhos = table.Column<int>(type: "INTEGER", nullable: false),
                    Criterio5CartoesAmarelos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoClassificacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoClassificacao");

            migrationBuilder.DropColumn(
                name: "SelecaoClassificada1",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "SelecaoClassificada2",
                table: "GruposSelecoes");
        }
    }
}
