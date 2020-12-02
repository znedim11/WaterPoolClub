using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class testingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrisustvoNaTreninzima",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.DropIndex(
                name: "IX_PrisustvoNaTreninzima_TreningId",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrisustvoNaTreninzima",
                table: "PrisustvoNaTreninzima",
                columns: new[] { "TreningId", "ClanId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrisustvoNaTreninzima",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PrisustvoNaTreninzima",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrisustvoNaTreninzima",
                table: "PrisustvoNaTreninzima",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PrisustvoNaTreninzima_TreningId",
                table: "PrisustvoNaTreninzima",
                column: "TreningId");
        }
    }
}
