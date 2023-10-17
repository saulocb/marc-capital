using Arrow.DeveloperTest.Common.Enum;
using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Infrastructure.Interfaces;
using System;

namespace Arrow.DeveloperTest.Infrastructure.Repository
{
    /// <summary>
    /// the repository implementation for AccountDataStore
    /// </summary>
    public class AccountDataStore : IAccountDataStoreRepository
    {
        private static Random _random = new Random();
        public Account GetAccount(string accountNumber)
        {
            // Simulate a database fetch with random data
            var account = new Account
            {
                AccountNumber = accountNumber,
                Balance = _random.Next(0, 10000), 
                Status = (AccountStatus)_random.Next(0, 3),  
                AllowedPaymentSchemes = (AllowedPaymentSchemes)_random.Next(1, 8)
            };
            return account;
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
