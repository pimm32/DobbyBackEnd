using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobby.Data.Migrations
{
    public partial class SeedZettenEnPartijenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) 
        {
            migrationBuilder
                .Sql("INSERT INTO partijen (Witspeler, Zwartspeler) VALUES ('Pim Arts', 'Job Arts')");
            migrationBuilder
               .Sql("INSERT INTO partijen (Witspeler, Zwartspeler) VALUES ('Job Arts', 'Pim Arts')");

            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(32, 28, (SELECT Id FROM partijen WHERE Witspeler='Pim Arts' AND Zwartspeler ='Job Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(20, 25, (SELECT Id FROM partijen WHERE Witspeler='Pim Arts' AND Zwartspeler ='Job Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(37, 32, (SELECT Id FROM partijen WHERE Witspeler='Pim Arts' AND Zwartspeler ='Job Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(15, 20, (SELECT Id FROM partijen WHERE Witspeler='Pim Arts' AND Zwartspeler ='Job Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(32, 27, (SELECT Id FROM partijen WHERE Witspeler='Job Arts' AND Zwartspeler ='Pim Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(19, 23, (SELECT Id FROM partijen WHERE Witspeler='Job Arts' AND Zwartspeler ='Pim Arts'))");
            migrationBuilder
                .Sql("INSERT INTO zetten (BeginVeld, EindVeld, PartijId) VALUES(37, 32, (SELECT Id FROM partijen WHERE Witspeler='Job Arts' AND Zwartspeler ='Pim Arts'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder
        .Sql("DELETE FROM Partijen");
        migrationBuilder
            .Sql("DELETE FROM Zetten");
        }
    }
}
