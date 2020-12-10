using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Dobby.Data.Migrations
{
    public partial class FirstTryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Witspeler",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "Zwartspeler",
                table: "Partijen");

            migrationBuilder.AddColumn<int>(
                name: "GebruikerId",
                table: "Partijen",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeeltempoFisherSeconden",
                table: "Partijen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeeltempoMinuten",
                table: "Partijen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TijdWitSpeler",
                table: "Partijen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TijdZwartSpeler",
                table: "Partijen",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PartijId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Partijen_PartijId",
                        column: x => x.PartijId,
                        principalTable: "Partijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Gebruikersnaam = table.Column<string>(maxLength: 50, nullable: false),
                    Rating = table.Column<int>(nullable: false, defaultValue: 1200)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Berichten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tekst = table.Column<string>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    AfzenderId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berichten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Berichten_Gebruikers_AfzenderId",
                        column: x => x.AfzenderId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Berichten_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerContacten",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerContacten", x => new { x.GebruikerId, x.ContactId });
                    table.ForeignKey(
                        name: "FK_GebruikerContacten_Gebruikers_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerContacten_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GebruikerId = table.Column<int>(nullable: true),
                    RatingAanBeginVanWedstrijd = table.Column<int>(nullable: false),
                    PartijId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spelers_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spelers_Partijen_PartijId",
                        column: x => x.PartijId,
                        principalTable: "Partijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partijen_GebruikerId",
                table: "Partijen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Berichten_AfzenderId",
                table: "Berichten",
                column: "AfzenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Berichten_ChatId",
                table: "Berichten",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_PartijId",
                table: "Chats",
                column: "PartijId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerContacten_ContactId",
                table: "GebruikerContacten",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_GebruikerId",
                table: "Spelers",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers",
                column: "PartijId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partijen_Gebruikers_GebruikerId",
                table: "Partijen",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partijen_Gebruikers_GebruikerId",
                table: "Partijen");

            migrationBuilder.DropTable(
                name: "Berichten");

            migrationBuilder.DropTable(
                name: "GebruikerContacten");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropIndex(
                name: "IX_Partijen_GebruikerId",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "GebruikerId",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "SpeeltempoFisherSeconden",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "SpeeltempoMinuten",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "TijdWitSpeler",
                table: "Partijen");

            migrationBuilder.DropColumn(
                name: "TijdZwartSpeler",
                table: "Partijen");

            migrationBuilder.AddColumn<string>(
                name: "Witspeler",
                table: "Partijen",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zwartspeler",
                table: "Partijen",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
