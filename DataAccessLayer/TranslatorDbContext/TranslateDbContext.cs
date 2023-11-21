using Microsoft.EntityFrameworkCore;
using TranslatorApp.Entities;

namespace TranslatorApp.DataAccessLayer.TranslatorDbContext
{
    public class TranslateDbContext : DbContext
    {
        public TranslateDbContext(DbContextOptions<TranslateDbContext> options) : base(options)
        {

        }
        public DbSet<Word> Words { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
          .HasIndex(e => e.Azerbaycan)
          .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
