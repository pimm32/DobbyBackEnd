using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobby.Data.Migrations
{
    public partial class AddedUniqueConstraintForContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerContacten_GebruikerId_ContactId",
                table: "GebruikerContacten",
                columns: new[] { "GebruikerId", "ContactId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GebruikerContacten_GebruikerId",
                table: "GebruikerContacten",
                column: "GebruikerId");
        }
    }
}
