using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MangoWiki.Sql;
using MangoWiki.Configuration;
using MangoWiki.Models;

namespace MangoWiki.Services
{
    public class RepositoryService : IRepositoryService
    {
        private bool databaseSetup;

        public RepositoryService()
        {
            databaseSetup = false;
        }

        public bool IsDatabaseSetup()
        {
            return databaseSetup;
        }

        public virtual void SetupDatabase(IServiceCollection services, IConfig config)
        {
            services.AddDbContext<MangoWikiDbContext>(
                options => options.UseMySql(config.DatabaseConnectionString)
            );

            services.AddIdentity<MangoWikiUser, IdentityRole>().AddEntityFrameworkStores<MangoWikiIdentityContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5; // error on side of caution
            });
        }
    }
}
