using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MangoWiki.Models;

namespace MangoWiki.Sql
{
    public class MangoWikiIdentityContext : IdentityDbContext<MangoWikiUser>
    {
       public MangoWikiIdentityContext(DbContextOptions<MangoWikiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Name = "Administrators",
                    NormalizedName = "Administrators".ToUpper()
                }
            }); 
        }

        public static void SeedData (MangoWikiIdentityContext context)
        {
            context.Database.Migrate();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
