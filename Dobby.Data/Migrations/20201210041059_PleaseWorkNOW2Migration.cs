using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobby.Data.Migrations
{
    public partial class PleaseWorkNOW2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "KleurSpeler",
                table: "Spelers",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kleur",
                table: "Spelers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
