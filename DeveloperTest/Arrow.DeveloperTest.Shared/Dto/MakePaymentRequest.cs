﻿using System;

namespace Arrow.DeveloperTest.Shared.Dto
{
    public class MakePaymentRequest
    {
        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentSchemeDto PaymentScheme { get; set; }
    }
}