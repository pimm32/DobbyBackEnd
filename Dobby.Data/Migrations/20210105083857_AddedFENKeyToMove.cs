using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobby.Data.Migrations
{
    public partial class AddedFENKeyToMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StandNaZet",
                table: "Zetten",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Uitslag",
                table: "Partijen",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandNaZet",
                table: "Zetten");

            migrationBuilder.DropColumn(
                name: "Uitslag",
                table: "Partijen");
        }
    }
}
