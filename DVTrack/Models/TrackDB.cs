using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVTrack.Models
{
    public class TrackContext : DbContext
    {
        public TrackContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<BoosterEvent> Events { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Officer> BoosterOfficers { get; set; }

    }
}