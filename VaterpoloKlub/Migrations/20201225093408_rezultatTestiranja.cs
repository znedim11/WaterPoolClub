using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class rezultatTestiranja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClanId",
                table: "Testiranja");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumTestiranja",
                table: "Testiranja",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NazivTestiranja",
                table: "Testiranja",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vjezbe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivVjezbe = table.Column<string>(nullable: true),
                    MjernaJedinica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjezbe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RezultatiTestiranja",
                columns: table => new
                {
                    TestiranjeId = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: false),
                    VjezbaId = table.Column<int>(nullable: false),
                    Rezultat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatiTestiranja", x => new { x.ClanId, x.TestiranjeId, x.VjezbaId });
                    table.ForeignKey(
                        name: "FK_RezultatiTestiranja_Clanovi_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clanovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezultatiTestiranja_Testiranja_TestiranjeId",
                        column: x => x.TestiranjeId,
                        principalTable: "Testiranja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezultatiTestiranja_Vjezbe_VjezbaId",
                        column: x => x.VjezbaId,
                        principalTable: "Vjezbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testiranja_TrenerId",
                table: "Testiranja",
                column: "TrenerId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatiTestiranja_TestiranjeId",
                table: "RezultatiTestiranja",
                column: "TestiranjeId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatiTestiranja_VjezbaId",
                table: "RezultatiTestiranja",
                column: "VjezbaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testiranja_Treneri_TrenerId",
                table: "Testiranja",
                column: "TrenerId",
                principalTable: "Treneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testiranja_Treneri_TrenerId",
                table: "Testiranja");

            migrationBuilder.DropTable(
                name: "RezultatiTestiranja");

            migrationBuilder.DropTable(
                name: "Vjezbe");

            migrationBuilder.DropIndex(
                name: "IX_Testiranja_TrenerId",
                table: "Testiranja");

            migrationBuilder.DropColumn(
                name: "DatumTestiranja",
                table: "Testiranja");

            migrationBuilder.DropColumn(
                name: "NazivTestiranja",
                table: "Testiranja");

            migrationBuilder.AddColumn<int>(
                name: "ClanId",
                table: "Testiranja",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
