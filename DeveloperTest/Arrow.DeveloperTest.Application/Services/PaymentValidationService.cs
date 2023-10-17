using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Application.Services
{
    public class PaymentValidationService : IPaymentValidationService
    {
        /// <summary>
        /// Check if Bacs payment is allowed. use domain business logic.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool IsBacsPaymentAllowed(Account account)
        {
            return account.IsBacsPaymentAllowed();
        }

        /// <summary>
        /// Check if Faster payment is allowed. use domain business logic.
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        /// <returns></returns>
        public bool IsFasterPaymentAllowed(Account account, decimal amount)
        {
            return account.IsFasterPaymentAllowed(amount);
        }

        /// <summary>
        /// Check if Chaps payment is allowed. use domain business logic.
        /// </summary>
        /// <param name="account">account</param>
        /// <returns></returns>
        public bool IsChapsPaymentAllowed(Account account)
        {
            return account.IsChapsPaymentAllowed();
        }

    }
}
