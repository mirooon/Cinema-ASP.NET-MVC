using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Context
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Web;
    using global::Cinema.Models;

    namespace Cinema.Context
    {
        public class CinemaDbContext : IdentityDbContext<ApplicationUser>
        {
            public CinemaDbContext()
                : base("DefaultConnection")
            {

            }
            public static CinemaDbContext Create()
            {
                return new CinemaDbContext();
            }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<CinemaPlace> Cinemas { get; set; }
            public DbSet<AgeRestriction> AgesRestriction { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<MovieType> MovieTypes { get; set; }
            public DbSet<MoviePosition> MoviePositions { get; set; }
            public DbSet<MoviePositionDates> MoviePositionsDates { get; set; }
            public DbSet<Banner> Banners { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<News> News { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            }
        }
    }
}