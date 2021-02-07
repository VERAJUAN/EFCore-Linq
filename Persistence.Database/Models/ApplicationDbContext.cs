using Microsoft.EntityFrameworkCore;
using Persistence.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True");
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PostConfig(modelBuilder.Entity<Post>());
            new TagConfig(modelBuilder.Entity<Tag>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
