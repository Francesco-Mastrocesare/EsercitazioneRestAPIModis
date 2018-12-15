using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModisAPI.Migrations
{
    public partial class Nuovetabellecorsiedesami : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Esami",
                columns: table => new
                {
                    EsameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Durata = table.Column<int>(nullable: false),
                    DataEsame = table.Column<DateTime>(nullable: false),
                    LuogoEsame = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esami", x => x.EsameId);
                });

            migrationBuilder.CreateTable(
                name: "EsamiStudenti",
                columns: table => new
                {
                    EsameId = table.Column<int>(nullable: false),
                    Voto = table.Column<int>(nullable: false),
                    StudenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsamiStudenti", x => new { x.StudenteId, x.EsameId });
                    table.ForeignKey(
                        name: "FK_EsamiStudenti_Esami_EsameId",
                        column: x => x.EsameId,
                        principalTable: "Esami",
                        principalColumn: "EsameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EsamiStudenti_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EsamiStudenti_EsameId",
                table: "EsamiStudenti",
                column: "EsameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EsamiStudenti");

            migrationBuilder.DropTable(
                name: "Esami");
        }
    }
}
