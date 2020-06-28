using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BursumMobil.Models
{
    public class BursumMobilContext:DbContext
    {
        public BursumMobilContext() : base("bursConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Bursiyer> BursAlanlar { get; set; }
        public DbSet<BursVeren> BursVerenler { get; set; }
        public DbSet<Burslar> Burslar { get; set; }
        public DbSet<OnayBekleyenler> OnayBekleyenler { get; set; }

    }
}
