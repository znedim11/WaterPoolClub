using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Models;

namespace VaterpoloKlub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@" Server=DESKTOP-P6SG32L\MSSQLSERVERR;
                                        Database=Sprint1;
                                        Trusted_Connection=true;
                                        MultipleActiveResultSets=true; ");

        }
        public DbSet<Clan> Clan { get; set; }

    }
}
