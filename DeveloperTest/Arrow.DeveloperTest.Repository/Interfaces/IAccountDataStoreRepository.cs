using Arrow.DeveloperTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Infrastructure.Interfaces
{
    /// <summary>
    /// repository interface for AccountDataStore
    /// </summary>
    public interface IAccountDataStoreRepository
    {
        /// <summary>
        /// Method to Get account
        /// </summary>
        /// <param name="accountNumber">the accountNumber.</param>
        /// <returns></returns>
        public Account GetAccount(string accountNumber);

        /// <summary>
        /// Method to update account
        /// </summary>
        /// <param name="account">account.</param>
        public void UpdateAccount(Account account);

    }
}
