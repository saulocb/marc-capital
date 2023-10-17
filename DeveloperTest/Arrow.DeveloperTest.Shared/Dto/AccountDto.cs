namespace Arrow.DeveloperTest.Shared.Dto
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatusDto Status { get; set; }
        public AllowedPaymentSchemesDto AllowedPaymentSchemes { get; set; }
    }
}
