using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Database.Options
{
    public static class OptionsExtensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
           where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}
