using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobby.Data.Migrations
{
    public partial class PotentialFixForForeignKeyFailureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers");

            migrationBuilder.AlterColumn<string>(
                name: "KleurSpeler",
                table: "Spelers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers",
                column: "PartijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers");

            migrationBuilder.AlterColumn<string>(
                name: "KleurSpeler",
                table: "Spelers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers",
                column: "PartijId",
                unique: true);
        }
    }
}
