using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class Addeddatabaseschemaforthewholeapplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Treneri",
                table: "Treneri");

            migrationBuilder.RenameTable(
                name: "Treneri",
                newName: "Trener");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trener",
                table: "Trener",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Mjesto = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Kontakt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trener",
                table: "Trener");

            migrationBuilder.RenameTable(
                name: "Trener",
                newName: "Treneri");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treneri",
                table: "Treneri",
                column: "Id");
        }
    }
}
