using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application
{
    public static class Extensions
    {
        public static IServiceProvider AddApplication(this IServiceCollection services)
        {
            var builder = services.AddConvey()
                .AddCommandHandlers()
                .AddQueryHandlers();

            return builder.Build();
        }
    }
}
