using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class AddedTrenings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lokacija",
                table: "VrstaTreninga");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "VrstaTreninga");

            migrationBuilder.AddColumn<string>(
                name: "NazivTreninga",
                table: "VrstaTreninga",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivTreninga",
                table: "VrstaTreninga");

            migrationBuilder.AddColumn<string>(
                name: "Lokacija",
                table: "VrstaTreninga",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "VrstaTreninga",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
