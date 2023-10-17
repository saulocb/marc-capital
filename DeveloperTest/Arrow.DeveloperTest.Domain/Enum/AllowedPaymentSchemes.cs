namespace Arrow.DeveloperTest.Domain.Enum
{
    /// <summary>
    /// Enum to represent the allowed payment schemes
    /// </summary>
    public enum AllowedPaymentSchemes
    {
        /// <summary>
        /// faster payments
        /// </summary>
        FasterPayments = 1 << 0,

        /// <summary>
        /// bacs
        /// </summary>
        Bacs = 1 << 1,

        /// <summary>
        /// chaps
        /// </summary>
        Chaps = 1 << 2
    }
}
