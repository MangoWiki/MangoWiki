using Microsoft.EntityFrameworkCore;
using MangoWiki.Models;

namespace MangoWiki.Data
{
    public class MangoWikiDbContext : DbContext
    {

        public MangoWikiDbContext(DbContextOptions<MangoWikiDbContext> options) : base(options)
        {
        }

        public DbSet<ErrorLogEntry> ErrorLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ErrorLogEntry>();
        }

    }
}
