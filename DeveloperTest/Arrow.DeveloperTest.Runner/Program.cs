using Microsoft.Extensions.DependencyInjection;
using System;
using Arrow.DeveloperTest.Infrastructure;
using Arrow.DeveloperTest.Application;
using Microsoft.Extensions.Configuration;
using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Shared.Dto;

namespace Arrow.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var service  = ConFiguration();

            // Resolve dependencies
            var paymentService = service.GetService<IPaymentService>();

            // Sample usage of payment service
            var paymentResult = paymentService.MakePayment(new MakePaymentRequest
            {
                CreditorAccountNumber = "123456789",  
                DebtorAccountNumber = "987654321",   
                Amount = 100.50M,                    
                PaymentDate = DateTime.Now,        
                PaymentScheme = PaymentSchemeDto.Bacs
            });

            if (paymentResult.Success)
            {
                Console.WriteLine("Payment successful!");
            }
            else
            {
                Console.WriteLine("Payment failed!");
            }
        }


        /// <summary>
        /// To Set the initial ap configuration and DI.
        /// </summary>
        public static ServiceProvider ConFiguration()
        {
           return new ServiceCollection()
                    .AddInfrastructureServices()
                    .AddApplicationServices()
                    .BuildServiceProvider();
        }

    }
}

