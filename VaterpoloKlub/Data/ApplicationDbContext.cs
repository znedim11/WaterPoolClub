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
        public DbSet<OrganizacijaZaCertifikacije> OrganizacijaZaCertifikacije { get; set; }
        public DbSet<Certifikat> Certifikati{ get; set; }
        public DbSet<PolaganjeCertifikata> PolaganjeCertifikata { get; set; }
        public DbSet<Testiranje> Testiranja { get; set; }
        public DbSet<PrisustvoNaTreningu> PrisustvoNaTreninzima { get; set; }
        public DbSet<Trening> Treninzi { get; set; }
        public DbSet<Takmicenje> Takmicenja { get; set; }
        public DbSet<RezultatTakmicenja> RezultatTakmicenja { get; set; }
        public DbSet<Nagrada> Nagrade { get; set; }
        public DbSet<Utakmica> Utakmice { get; set; }
        public DbSet<ClanUEkipi> ClanUEkipama { get; set; }
        public DbSet<Ekipa> Ekipe { get; set; }
        public DbSet<NaplataClanarine> NaplataClanarina { get; set; }
        public DbSet<Upravnik> Upravnici { get; set; }
        public DbSet<Clanarina> Clanarine { get; set; }
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
            optionsBuilder.UseSqlServer(@"Server=.;Database=seminarskiRad;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PrisustvoNaTreningu>()
                   .HasKey(bc => new { bc.TreningId, bc.ClanId });
            builder.Entity<PrisustvoNaTreningu>()
                .HasOne(bc => bc.Clan)
                .WithMany(b => b.PrisustvoNaTreningu)
                .HasForeignKey(bc => bc.ClanId);
            builder.Entity<PrisustvoNaTreningu>()
                .HasOne(bc => bc.Trening)
                .WithMany(c => c.PrisustvoNaTreningu)
                .HasForeignKey(bc => bc.TreningId);
            base.OnModelCreating(builder);
        }
    }
}