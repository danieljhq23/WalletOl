using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Interfaces;
using Wallet.Repositories;
using Wallet.Services;

namespace Wallet.Middleware
{
    public static class BusinessDependencies
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<CoreAccountRepository>();

            services.AddScoped<CoreClientRepository>();

            return services;
        }
    }
}
