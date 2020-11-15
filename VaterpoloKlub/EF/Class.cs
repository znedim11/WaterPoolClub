using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VaterpoloKlub.Models;

namespace Sprint1.EF
{
    public class SprintDbContext:DbContext
    {

        public DbSet<Clan> Clan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@" Server=DESKTOP-P6SG32L\MSSQLSERVERR;
                                        Database=Sprint1;
                                        Trusted_Connection=true;
                                        MultipleActiveResultSets=true; ");

        }
    }
}
