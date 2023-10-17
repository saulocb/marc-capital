using Arrow.DeveloperTest.Common.Enum;
using Arrow.DeveloperTest.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Tests.Domain
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void IsBacsPaymentAllowed_BacsIsAllowed_ReturnsTrue()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };

            var result = account.IsBacsPaymentAllowed();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBacsPaymentAllowed_BacsIsNotAllowed_ReturnsFalse()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps };

            var result = account.IsBacsPaymentAllowed();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFasterPaymentAllowed_FasterPaymentsIsAllowedAndSufficientBalance_ReturnsTrue()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 100 };

            var result = account.IsFasterPaymentAllowed(50);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFasterPaymentAllowed_InsufficientBalance_ReturnsFalse()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 30 };

            var result = account.IsFasterPaymentAllowed(50);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsChapsPaymentAllowed_ChapsIsAllowedAndStatusIsLive_ReturnsTrue()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live };

            var result = account.IsChapsPaymentAllowed();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsChapsPaymentAllowed_StatusIsNotLive_ReturnsFalse()
        {
            var account = new Account { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Disabled };

            var result = account.IsChapsPaymentAllowed();

            Assert.IsFalse(result);
        }
    }
}
