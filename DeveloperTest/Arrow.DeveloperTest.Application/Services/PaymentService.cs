﻿using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Common.Enum;
using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Infrastructure.Interfaces;
using Arrow.DeveloperTest.Shared.Dto;
using System;

namespace Arrow.DeveloperTest.Application.Services
{
    /// <summary>
    /// The implementation of the payment service.
    /// </summary>
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// The account data store DI.
        /// </summary>
        private readonly IAccountDataStoreRepository _accountDataStore;

        /// <summary>
        /// The payment validation service DI.
        /// </summary>
        private readonly IPaymentValidationService _paymentValidationService;

        /// <summary>
        /// the constructor of the payment service.
        /// </summary>
        /// <param name="accountDataStore">accountDataStore.</param>
        /// <param name="IPaymentValidationService">IPaymentValidationService.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public PaymentService(IAccountDataStoreRepository accountDataStore, IPaymentValidationService paymentValidationService)
        {
            _accountDataStore = accountDataStore ?? throw new System.ArgumentNullException(nameof(accountDataStore));
            _paymentValidationService = paymentValidationService ?? throw new System.ArgumentNullException(nameof(paymentValidationService));
        }

        /// <summary>
        /// The implementation of the make payment method.
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns></returns>
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult();

            if (string.IsNullOrEmpty(request.DebtorAccountNumber)) throw new ArgumentNullException(nameof(request.DebtorAccountNumber));

            Account account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            if (account == null)
            {
                result.Success = false;
                return result;
            }

            switch (request.PaymentScheme)
            {
                case PaymentScheme.Bacs:
                    result.Success = _paymentValidationService.IsBacsPaymentAllowed(account);
                    break;
                case PaymentScheme.FasterPayments:
                    result.Success = _paymentValidationService.IsFasterPaymentAllowed(account, request.Amount);
                    break;
                case PaymentScheme.Chaps:
                    result.Success = _paymentValidationService.IsChapsPaymentAllowed(account);
                    break;
            }

            if (result.Success)
            {
                UpdateAccountBalance(account, request.Amount);
            }

            return result;
        }

        /// <summary>
        /// private method to update the account balance.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void UpdateAccountBalance(Account account, decimal amount)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));

            account.Balance -= amount;

            _accountDataStore.UpdateAccount(account);
        }
    }
}
