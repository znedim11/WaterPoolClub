using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class fixPrisustvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prisutan",
                table: "PrisustvoNaTreninzima",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prisutan",
                table: "PrisustvoNaTreninzima");
        }
    }
}
