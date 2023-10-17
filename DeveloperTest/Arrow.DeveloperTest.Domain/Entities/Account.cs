
using Arrow.DeveloperTest.Common.Enum;

namespace Arrow.DeveloperTest.Domain.Entities
{
    /// <summary>
    /// Teh domain class for an account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// account number
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the payment scheme.
        /// </summary>
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public bool IsBacsPaymentAllowed()
        {
            return this.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
        }

        public bool IsFasterPaymentAllowed(decimal amount)
        {
            return this.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) && this.Balance >= amount;
        }

        public bool IsChapsPaymentAllowed()
        {
            return this.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) && this.Status == AccountStatus.Live;
        }
    }
}
