using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Application.Services
{
    public class PaymentValidationService : IPaymentValidationService
    {
        public bool IsBacsPaymentAllowed(Account account)
        {
            if (account == null) return false;
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
        }

        public bool IsFasterPaymentAllowed(Account account, decimal amount)
        {
            if (account == null) return false;
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) && account.Balance >= amount;
        }

        public bool IsChapsPaymentAllowed(Account account)
        {
            if (account == null) return false;
            return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) && account.Status == AccountStatus.Live;
        }

    }
}
