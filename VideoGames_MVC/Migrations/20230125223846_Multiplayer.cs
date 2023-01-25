using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames_MVC.Migrations
{
    public partial class Multiplayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MultiPlayer",
                table: "VideoGames",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultiPlayer",
                table: "VideoGames");
        }
    }
}
