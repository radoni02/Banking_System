using Banking.Infrastructure.Database.Contexts;
using Banking.Infrastructure.Database.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services,IConfiguration configuration)
        {
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
            return services;
        }
    }
}
