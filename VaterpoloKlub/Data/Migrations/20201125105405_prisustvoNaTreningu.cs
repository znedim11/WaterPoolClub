using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class prisustvoNaTreningu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PrisustvoNaTreninzima_ClanId",
                table: "PrisustvoNaTreninzima",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisustvoNaTreninzima_TreningId",
                table: "PrisustvoNaTreninzima",
                column: "TreningId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrisustvoNaTreninzima_Clanovi_ClanId",
                table: "PrisustvoNaTreninzima",
                column: "ClanId",
                principalTable: "Clanovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrisustvoNaTreninzima_Treninzi_TreningId",
                table: "PrisustvoNaTreninzima",
                column: "TreningId",
                principalTable: "Treninzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrisustvoNaTreninzima_Clanovi_ClanId",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.DropForeignKey(
                name: "FK_PrisustvoNaTreninzima_Treninzi_TreningId",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.DropIndex(
                name: "IX_PrisustvoNaTreninzima_ClanId",
                table: "PrisustvoNaTreninzima");

            migrationBuilder.DropIndex(
                name: "IX_PrisustvoNaTreninzima_TreningId",
                table: "PrisustvoNaTreninzima");
        }
    }
}
