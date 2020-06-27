using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MangoWiki.Repositories;
using MangoWiki.Sql.Repositories;
using MangoWiki.Models;
using MangoWiki.Configuration;
using MangoWiki.Data;

namespace MangoWiki.Sql
{
    public static class Extensions
    {
        public static void AddMangoWikiSql(this IServiceCollection services)
        {
            services.AddTransient<IErrorLogRepository, ErrorLogRepository>();
        }

        public static void AddMangoWikiDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configService = serviceProvider.GetService<IConfig>();

            services.AddDbContext<MangoWikiDbContext>(
                options => options.UseMySql(configService.DatabaseConnectionString)
            );

            /* services.AddIdentity<MangoWikiUser, IdentityRole>().AddEntityFrameworkStores<MangoWikiIdentityContext>();

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
            }); */

        }
    }
}
