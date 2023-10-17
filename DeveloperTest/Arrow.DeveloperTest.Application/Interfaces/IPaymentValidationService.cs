using Arrow.DeveloperTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Application.Interfaces
{
    public interface IPaymentValidationService
    {
        bool IsBacsPaymentAllowed(Account account);
        bool IsFasterPaymentAllowed(Account account, decimal amount);
        bool IsChapsPaymentAllowed(Account account);
    }
}
