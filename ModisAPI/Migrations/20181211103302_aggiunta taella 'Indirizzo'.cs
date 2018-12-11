using Microsoft.EntityFrameworkCore.Migrations;

namespace ModisAPI.Migrations
{
    public partial class aggiuntataellaIndirizzo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Indirizzo",
                table: "Studenti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Indirizzo",
                table: "Studenti");
        }
    }
}
