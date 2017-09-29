using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.DatabaseService.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Masterarbeit.DatabaseService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<FixedWord> FixedWords { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<FixedWord>().ToTable("FixedWord");
            modelBuilder.Entity<Word>().ToTable("Words");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
