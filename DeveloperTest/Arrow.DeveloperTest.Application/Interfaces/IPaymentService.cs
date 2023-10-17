
using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Shared.Dto;

namespace Arrow.DeveloperTest.Application.Interfaces
{
    /// <summary>
    /// The payment service interface
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// The make payment method
        /// </summary>
        /// <param name="request">request.</param>
        /// <returns></returns>
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
