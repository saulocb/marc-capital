namespace Arrow.DeveloperTest.Shared.Dto
{
    public enum AllowedPaymentSchemesDto
    {
        FasterPayments = 1 << 0,
        Bacs = 1 << 1,
        Chaps = 1 << 2
    }
}
