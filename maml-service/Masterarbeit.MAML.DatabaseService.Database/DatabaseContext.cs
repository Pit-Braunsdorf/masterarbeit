using Masterarbeit.MAML.DatabaseService.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Masterarbeit.MAML.DatabaseService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FixedWord> FixedWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FixedWord>().ToTable("FixedWord");
        }
    }
}
