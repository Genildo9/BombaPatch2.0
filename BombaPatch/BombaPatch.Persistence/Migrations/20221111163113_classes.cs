using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaPatch.Persistence.Migrations
{
    public partial class classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_GruposSelecoes_Selecoes_SelecaoId",
                table: "GruposSelecoes");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropIndex(
                name: "IX_GruposSelecoes_JogosId",
                table: "GruposSelecoes");

            migrationBuilder.DropIndex(
                name: "IX_GruposSelecoes_SelecaoId",
                table: "GruposSelecoes");

            migrationBuilder.DropIndex(
                name: "IX_Estadios_JogosId",
                table: "Estadios");

            migrationBuilder.DropIndex(
                name: "IX_Arbitros_JogosId",
                table: "Arbitros");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "CartaoAmarelo",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "CartaoVermelho",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "Empates",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "GolsMarcados",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "GolsSofridos",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "Jogos",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "SaldoGols",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "SelecaoId",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "GruposSelecoes");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "Estadios");

            migrationBuilder.DropColumn(
                name: "JogosId",
                table: "Arbitros");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Selecoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoSelecaoId",
                table: "Selecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArbitroId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadioId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultadoId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelecaoAId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelecaoBId",
                table: "Jogos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResultadoSelecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SelecaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pontos = table.Column<int>(type: "INTEGER", nullable: false),
                    GolsMarcados = table.Column<int>(type: "INTEGER", nullable: false),
                    GolsSofridos = table.Column<int>(type: "INTEGER", nullable: false),
                    CartaoAmarelo = table.Column<int>(type: "INTEGER", nullable: false),
                    CartaoVermelho = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoSelecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoJogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SelecaoJogoResultadoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoJogoResultadoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    Resultado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoJogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadoJogos_ResultadoSelecao_SelecaoJogoResultadoAId",
                        column: x => x.SelecaoJogoResultadoAId,
                        principalTable: "ResultadoSelecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultadoJogos_ResultadoSelecao_SelecaoJogoResultadoBId",
                        column: x => x.SelecaoJogoResultadoBId,
                        principalTable: "ResultadoSelecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selecoes_GrupoId",
                table: "Selecoes",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_ResultadoId",
                table: "Jogos",
                column: "ResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoJogos_SelecaoJogoResultadoAId",
                table: "ResultadoJogos",
                column: "SelecaoJogoResultadoAId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoJogos_SelecaoJogoResultadoBId",
                table: "ResultadoJogos",
                column: "SelecaoJogoResultadoBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_ResultadoJogos_ResultadoId",
                table: "Jogos",
                column: "ResultadoId",
                principalTable: "ResultadoJogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos",
                column: "SelecaoAId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos",
                column: "SelecaoBId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selecoes_GruposSelecoes_GrupoId",
                table: "Selecoes",
                column: "GrupoId",
                principalTable: "GruposSelecoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_ResultadoJogos_ResultadoId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Selecoes_SelecaoBId",
                table: "Jogos");

            migrationBuilder.DropForeignKey(
                name: "FK_Selecoes_GruposSelecoes_GrupoId",
                table: "Selecoes");

            migrationBuilder.DropTable(
                name: "ResultadoJogos");

            migrationBuilder.DropTable(
                name: "ResultadoSelecao");

            migrationBuilder.DropIndex(
                name: "IX_Selecoes_GrupoId",
                table: "Selecoes");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_ResultadoId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_SelecaoBId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Selecoes");

            migrationBuilder.DropColumn(
                name: "GrupoSelecaoId",
                table: "Selecoes");

            migrationBuilder.DropColumn(
                name: "ArbitroId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "EstadioId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "ResultadoId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SelecaoAId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "SelecaoBId",
                table: "Jogos");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CartaoAmarelo",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartaoVermelho",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empates",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsMarcados",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsSofridos",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jogos",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JogosId",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaldoGols",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelecaoId",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "GruposSelecoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArbitroId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadioId = table.Column<int>(type: "INTEGER", nullable: false),
                    FaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Jogo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Arbitros_ArbitroId",
                        column: x => x.ArbitroId,
                        principalTable: "Arbitros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidas_Estadios_EstadioId",
                        column: x => x.EstadioId,
                        principalTable: "Estadios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partidas_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GruposSelecoes_JogosId",
                table: "GruposSelecoes",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_GruposSelecoes_SelecaoId",
                table: "GruposSelecoes",
                column: "SelecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estadios_JogosId",
                table: "Estadios",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_JogosId",
                table: "Arbitros",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_ArbitroId",
                table: "Partidas",
                column: "ArbitroId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_EstadioId",
                table: "Partidas",
                column: "EstadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_FaseId",
                table: "Partidas",
                column: "FaseId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GruposSelecoes_Selecoes_SelecaoId",
                table: "GruposSelecoes",
                column: "SelecaoId",
                principalTable: "Selecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
