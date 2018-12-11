using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModisAPI.Migrations
{
    public partial class CreazioneDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    CorsoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    DurataInOre = table.Column<int>(nullable: false),
                    Livello = table.Column<int>(nullable: false),
                    NumeroMassimoPartecipanti = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.CorsoId);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudenteCorsi",
                columns: table => new
                {
                    StudenteId = table.Column<int>(nullable: false),
                    CorsoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenteCorsi", x => new { x.StudenteId, x.CorsoId });
                    table.ForeignKey(
                        name: "FK_StudenteCorsi_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "CorsoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudenteCorsi_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudenteCorsi_CorsoId",
                table: "StudenteCorsi",
                column: "CorsoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudenteCorsi");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
