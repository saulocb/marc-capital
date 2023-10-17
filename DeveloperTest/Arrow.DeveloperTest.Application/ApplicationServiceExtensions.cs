using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentValidationService, PaymentValidationService>();  
            return services;
        }
    }
}
