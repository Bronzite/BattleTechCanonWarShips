using BattleTechCanonWarships.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Data
{
    public class WarshipsContext:DbContext, IDesignTimeDbContextFactory<WarshipsContext>
    {
        public WarshipsContext (DbContextOptions<WarshipsContext> options):base(options)
        {
            
        }

        public WarshipsContext():base()
        {

        }
        public WarshipsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarshipsContext>();
            optionsBuilder.UseSqlServer(SiteStatics.Configuration.GetSection("ConnectionStrings")["Default"]);

            return new WarshipsContext(optionsBuilder.Options);
        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<ShipClass> ShipClasses { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
