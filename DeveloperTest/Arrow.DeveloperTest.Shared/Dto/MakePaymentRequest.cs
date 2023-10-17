using Arrow.DeveloperTest.Common.Enum;
using System;

namespace Arrow.DeveloperTest.Shared.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Arrow.DeveloperTest.Common.Enum;

    public class MakePaymentRequest
    {
        [Required(ErrorMessage = "Creditor Account Number is required.")]
        [StringLength(20, ErrorMessage = "Creditor Account Number can't be longer than 20 characters.")]
        public string CreditorAccountNumber { get; set; }

        [Required(ErrorMessage = "Debtor Account Number is required.")]
        [StringLength(20, ErrorMessage = "Debtor Account Number can't be longer than 20 characters.")]
        public string DebtorAccountNumber { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid amount. Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Payment Scheme is required.")]
        public PaymentScheme PaymentScheme { get; set; }
    }

}
