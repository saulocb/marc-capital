using Arrow.DeveloperTest.Infrastructure.Interfaces;
using Arrow.DeveloperTest.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Arrow.DeveloperTest.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountDataStoreRepository, AccountDataStore>();
            return services;
        }
    }
}
