using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Dobby.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partijen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Witspeler = table.Column<string>(maxLength: 50, nullable: false),
                    Zwartspeler = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zetten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BeginVeld = table.Column<int>(nullable: false),
                    EindVeld = table.Column<int>(nullable: false),
                    PartijId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zetten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zetten_Partijen_PartijId",
                        column: x => x.PartijId,
                        principalTable: "Partijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zetten_PartijId",
                table: "Zetten",
                column: "PartijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zetten");

            migrationBuilder.DropTable(
                name: "Partijen");
        }
    }
}
