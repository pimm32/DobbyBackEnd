using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Dobby.Data.Migrations
{
    public partial class TweedeDatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Partijen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SpeeltempoMinuten = table.Column<int>(nullable: false),
                    SpeeltempoFisherSeconden = table.Column<int>(nullable: false),
                    TijdWitSpeler = table.Column<int>(nullable: false),
                    TijdZwartSpeler = table.Column<int>(nullable: false),
                    Uitslag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerContacten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GebruikerId = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerContacten", x => x.Id);
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
                name: "Spelers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GebruikerId = table.Column<int>(nullable: false),
                    RatingAanBeginVanWedstrijd = table.Column<int>(nullable: false),
                    PartijId = table.Column<int>(nullable: false),
                    KleurSpeler = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spelers_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spelers_Partijen_PartijId",
                        column: x => x.PartijId,
                        principalTable: "Partijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zetten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BeginVeld = table.Column<int>(nullable: false),
                    EindVeld = table.Column<int>(nullable: false),
                    StandNaZet = table.Column<string>(nullable: false),
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
                name: "IX_GebruikerContacten_GebruikerId",
                table: "GebruikerContacten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_GebruikerId",
                table: "Spelers",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_PartijId",
                table: "Spelers",
                column: "PartijId");

            migrationBuilder.CreateIndex(
                name: "IX_Zetten_PartijId",
                table: "Zetten",
                column: "PartijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berichten");

            migrationBuilder.DropTable(
                name: "GebruikerContacten");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Zetten");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Partijen");
        }
    }
}
