using Arrow.DeveloperTest.Application.Services;
using Arrow.DeveloperTest.Common.Enum;
using Arrow.DeveloperTest.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Tests.ServiceTest
{
    [TestClass]
    public class PaymentValidationServiceTests
    {
        private PaymentValidationService _paymentValidationService;

        [TestInitialize]
        public void SetUp()
        {
            _paymentValidationService = new PaymentValidationService();
        }

        [TestMethod]
        public void IsBacsPaymentAllowed_BacsIsAllowed_ReturnsTrue()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };

            var result = _paymentValidationService.IsBacsPaymentAllowed(account);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFasterPaymentAllowed_FasterPaymentsIsAllowedAndSufficientBalance_ReturnsTrue()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 100 };

            var result = _paymentValidationService.IsFasterPaymentAllowed(account, 50);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsChapsPaymentAllowed_ChapsIsAllowedAndStatusIsLive_ReturnsTrue()
        {
            // Arrange
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live };

            var result = _paymentValidationService.IsChapsPaymentAllowed(account);

            Assert.IsTrue(result);
        }
    }

}
