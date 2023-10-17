using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Infrastructure.Interfaces;

namespace Arrow.DeveloperTest.Infrastructure.Repository
{
    /// <summary>
    /// the repository implementation for AccountDataStore
    /// </summary>
    public class AccountDataStore : IAccountDataStoreRepository
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
