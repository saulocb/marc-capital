using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Application.Services;
using Arrow.DeveloperTest.Common.Enum;
using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Infrastructure.Interfaces;
using Arrow.DeveloperTest.Shared.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Arrow.DeveloperTest.Tests.ServiceTest
{
    [TestClass]
    public class PaymentServiceTests
    {
        private Mock<IAccountDataStoreRepository> _mockAccountDataStore;
        private Mock<IPaymentValidationService> _mockPaymentValidationService;
        private PaymentService _paymentService;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountDataStore = new Mock<IAccountDataStoreRepository>();
            _mockPaymentValidationService = new Mock<IPaymentValidationService>();
            _paymentService = new PaymentService(_mockAccountDataStore.Object, _mockPaymentValidationService.Object);
        }

        [TestMethod]
        public void MakePayment_WithValidBacsPayment_Succeeds()
        {
            // Arrange
            var account = new Account { AccountNumber = "123", Balance = 100, AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(account);
            _mockPaymentValidationService.Setup(x => x.IsBacsPaymentAllowed(It.IsAny<Account>())).Returns(true);
            var request = new MakePaymentRequest { DebtorAccountNumber = "123", PaymentScheme = PaymentScheme.Bacs, Amount = 50 };

            var result = _paymentService.MakePayment(request);

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void MakePayment_AccountDoesNotExist_ReturnsFalse()
        {
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns((Account)null);

            var result = _paymentService.MakePayment(new MakePaymentRequest());

            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void MakePayment_WithValidPayment_UpdatesAccountBalance()
        {
            var initialBalance = 100m;
            var paymentAmount = 50m;
            var account = new Account { AccountNumber = "123", Balance = initialBalance, AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };

            // Mock setups
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(account);
            _mockPaymentValidationService.Setup(x => x.IsBacsPaymentAllowed(It.IsAny<Account>())).Returns(true);

            var result = _paymentService.MakePayment(new MakePaymentRequest { DebtorAccountNumber = "123", PaymentScheme = PaymentScheme.Bacs, Amount = paymentAmount });

            Assert.IsTrue(result.Success);
            Assert.AreEqual(initialBalance - paymentAmount, account.Balance);
        }

        [TestMethod]
        public void MakePayment_WithValidFasterPayments_Succeeds()
        {
            // Arrange
            var account = new Account { AccountNumber = "123", Balance = 100, AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments };
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(account);
            _mockPaymentValidationService.Setup(x => x.IsFasterPaymentAllowed(It.IsAny<Account>(), It.IsAny<decimal>())).Returns(true);
            var request = new MakePaymentRequest { DebtorAccountNumber = "123", PaymentScheme = PaymentScheme.FasterPayments, Amount = 50 };

            var result = _paymentService.MakePayment(request);

            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void MakePayment_WithValidChapsPayment_Succeeds()
        {
            // Arrange
            var account = new Account { AccountNumber = "123", Balance = 100, AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live };
            _mockAccountDataStore.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(account);
            _mockPaymentValidationService.Setup(x => x.IsChapsPaymentAllowed(It.IsAny<Account>())).Returns(true);
            var request = new MakePaymentRequest { DebtorAccountNumber = "123", PaymentScheme = PaymentScheme.Chaps, Amount = 50 };

            var result = _paymentService.MakePayment(request);

            Assert.IsTrue(result.Success);
        }

    }
}
