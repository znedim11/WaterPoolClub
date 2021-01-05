using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class ClanUEkipi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClanUEkipama",
                table: "ClanUEkipama");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClanUEkipama");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Ekipe",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClanUEkipama",
                table: "ClanUEkipama",
                columns: new[] { "ClanId", "EkipaId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClanUEkipama_EkipaId",
                table: "ClanUEkipama",
                column: "EkipaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClanUEkipama_Clanovi_ClanId",
                table: "ClanUEkipama",
                column: "ClanId",
                principalTable: "Clanovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClanUEkipama_Ekipe_EkipaId",
                table: "ClanUEkipama",
                column: "EkipaId",
                principalTable: "Ekipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanUEkipama_Clanovi_ClanId",
                table: "ClanUEkipama");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanUEkipama_Ekipe_EkipaId",
                table: "ClanUEkipama");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClanUEkipama",
                table: "ClanUEkipama");

            migrationBuilder.DropIndex(
                name: "IX_ClanUEkipama_EkipaId",
                table: "ClanUEkipama");

            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Ekipe");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClanUEkipama",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClanUEkipama",
                table: "ClanUEkipama",
                column: "Id");
        }
    }
}
