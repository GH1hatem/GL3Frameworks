using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GL3Frameworks.Models;

namespace GL3Frameworks.Data
{
    public class GL3FrameworksContext : DbContext
    {
        public GL3FrameworksContext (DbContextOptions<GL3FrameworksContext> options)
            : base(options)
        {
        }
        // on model creation, we can use the fluent API to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
               .Ignore(b => b.Image);
        }

        public DbSet<GL3Frameworks.Models.Movie> Movie { get; set; } = default!;

        public DbSet<GL3Frameworks.Models.Customer>? Customer { get; set; }

        public DbSet<GL3Frameworks.Models.Membershiptype>? Membershiptype { get; set; }

        public DbSet<GL3Frameworks.Models.Genre>? Genre { get; set; }
    }
}
