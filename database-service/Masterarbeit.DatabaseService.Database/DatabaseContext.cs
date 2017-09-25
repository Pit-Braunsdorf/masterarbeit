using System;
using System.Collections.Generic;
using System.Text;
using Masterarbeit.DatabaseService.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Masterarbeit.DatabaseService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<FixedWord> FixedWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FixedWord>().ToTable("FixedWord");
        }
    }
}
