using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class AddedTrening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bazen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bazen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VrstaTreninga",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaTreninga", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    TrenerID = table.Column<int>(nullable: false),
                    BazenID = table.Column<int>(nullable: false),
                    VrstaTreningaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trening", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trening_Bazen_BazenID",
                        column: x => x.BazenID,
                        principalTable: "Bazen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trening_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Treneri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trening_VrstaTreninga_VrstaTreningaID",
                        column: x => x.VrstaTreningaID,
                        principalTable: "VrstaTreninga",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trening_BazenID",
                table: "Trening",
                column: "BazenID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_TrenerID",
                table: "Trening",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trening_VrstaTreningaID",
                table: "Trening",
                column: "VrstaTreningaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trening");

            migrationBuilder.DropTable(
                name: "Bazen");

            migrationBuilder.DropTable(
                name: "VrstaTreninga");
        }
    }
}
