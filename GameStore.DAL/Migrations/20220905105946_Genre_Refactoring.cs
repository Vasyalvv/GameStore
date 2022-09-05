using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.DAL.Migrations
{
    public partial class Genre_Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Games_GameId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GameId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GameId",
                table: "Genres",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Games_GameId",
                table: "Genres",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
