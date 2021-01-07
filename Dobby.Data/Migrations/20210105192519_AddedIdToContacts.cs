using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Dobby.Data.Migrations
{
    public partial class AddedIdToContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GebruikerContacten",
                table: "GebruikerContacten");

            migrationBuilder.AlterColumn<string>(
                name: "Uitslag",
                table: "Partijen",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GebruikerContacten",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GebruikerContacten",
                table: "GebruikerContacten",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerContacten_GebruikerId",
                table: "GebruikerContacten",
                column: "GebruikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GebruikerContacten",
                table: "GebruikerContacten");

            migrationBuilder.DropIndex(
                name: "IX_GebruikerContacten_GebruikerId",
                table: "GebruikerContacten");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GebruikerContacten");

            migrationBuilder.AlterColumn<int>(
                name: "Uitslag",
                table: "Partijen",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GebruikerContacten",
                table: "GebruikerContacten",
                columns: new[] { "GebruikerId", "ContactId" });
        }
    }
}
