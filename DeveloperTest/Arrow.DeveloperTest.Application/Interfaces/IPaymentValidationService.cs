using Arrow.DeveloperTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Application.Interfaces
{
    /// <summary>
    /// Service to validate payment
    /// </summary>
    public interface IPaymentValidationService
    {
        /// <summary>
        /// check if Bacs payment is allowed use dommain business logic
        /// </summary>
        /// <param name="account">account</param>
        /// <returns></returns>
        bool IsBacsPaymentAllowed(Account account);

        /// <summary>
        /// check if Faster payment is allowed use dommain business logic
        /// </summary>
        /// <param name="account">account</param>
        /// <param name="amount">amount</param>
        /// <returns></returns>
        bool IsFasterPaymentAllowed(Account account, decimal amount);

        /// <summary>
        /// Check if Chaps payment is allowed use dommain business logic
        /// </summary>
        /// <param name="account">account</param>
        /// <returns></returns>
        bool IsChapsPaymentAllowed(Account account);
    }
}
