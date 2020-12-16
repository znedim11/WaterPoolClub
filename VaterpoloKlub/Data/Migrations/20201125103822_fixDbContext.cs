using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaterpoloKlub.Migrations
{
    public partial class fixDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Certifikati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizacijaZaCertifikacijeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifikati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clanarine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPocketa = table.Column<DateTime>(nullable: false),
                    DatumKraja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClanUEkipama",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkipaId = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanUEkipama", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ekipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nagrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nagrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaplataClanarina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpravnikId = table.Column<int>(nullable: false),
                    ClanarinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaplataClanarina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizacijaZaCertifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacijaZaCertifikacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolaganjeCertifikata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false),
                    CertifikatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolaganjeCertifikata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrisustvoNaTreninzima",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreningId = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisustvoNaTreninzima", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RezultatTakmicenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkipaId = table.Column<int>(nullable: false),
                    TakmicenjeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatTakmicenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Takmicenja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takmicenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testiranja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testiranja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treninzi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenerId = table.Column<int>(nullable: false),
                    BazenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treninzi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upravnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upravnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utakmice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EkipaIdJedan = table.Column<int>(nullable: false),
                    EkipaIdDva = table.Column<int>(nullable: false),
                    BazenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmice", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifikati");

            migrationBuilder.DropTable(
                name: "Clanarine");

            migrationBuilder.DropTable(
                name: "ClanUEkipama");

            migrationBuilder.DropTable(
                name: "Ekipe");

            migrationBuilder.DropTable(
                name: "Nagrade");

            migrationBuilder.DropTable(
                name: "NaplataClanarina");

            migrationBuilder.DropTable(
                name: "OrganizacijaZaCertifikacije");

            migrationBuilder.DropTable(
                name: "PolaganjeCertifikata");

            migrationBuilder.DropTable(
                name: "PrisustvoNaTreninzima");

            migrationBuilder.DropTable(
                name: "RezultatTakmicenja");

            migrationBuilder.DropTable(
                name: "Takmicenja");

            migrationBuilder.DropTable(
                name: "Testiranja");

            migrationBuilder.DropTable(
                name: "Treninzi");

            migrationBuilder.DropTable(
                name: "Upravnici");

            migrationBuilder.DropTable(
                name: "Utakmice");

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
        }
    }
}
