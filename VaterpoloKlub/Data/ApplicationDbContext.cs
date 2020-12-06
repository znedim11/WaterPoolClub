using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Models;

namespace VaterpoloKlub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Trener> OrganizacijaZaCertifikacije { get; set; }
        public DbSet<Trener> Certifikati{ get; set; }
        public DbSet<Trener> PolaganjeCertifikata { get; set; }
        public DbSet<Trener> Testiranja { get; set; }
        public DbSet<Trener> PrisustvoNaTreninzima { get; set; }
        public DbSet<Trener> Treninzi { get; set; }
        public DbSet<Trener> Takmicenja { get; set; }
        public DbSet<Trener> RezultatTakmicenja { get; set; }
        public DbSet<Trener> Nagrade { get; set; }
        public DbSet<Trener> Utakmice { get; set; }
        public DbSet<Trener> ClanUEkipama { get; set; }
        public DbSet<Trener> Ekipe { get; set; }
        public DbSet<Trener> NaplataClanarina { get; set; }
        public DbSet<Trener> Upravnici { get; set; }
        public DbSet<Trener> Clanarine { get; set; }
        public DbSet<Trener> Treneri { get; set; }
        public DbSet<Trening> Trening { get; set; }
        public DbSet<Bazen> Bazen { get; set; }
        public DbSet<VrstaTreninga> VrstaTreninga { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P6SG32L\MSSQLSERVERR;Database=seminarskiRad;Trusted_Connection=True;");
        }
        
    }
}