using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BombaPatch.Persistence.Migrations
{
    public partial class elimina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eliminatoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroJogo = table.Column<int>(type: "INTEGER", nullable: false),
                    Fase = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoA = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoB = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoVencedora = table.Column<int>(type: "INTEGER", nullable: false),
                    SelecaoPerdedora = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eliminatoria", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eliminatoria");
        }
    }
}
