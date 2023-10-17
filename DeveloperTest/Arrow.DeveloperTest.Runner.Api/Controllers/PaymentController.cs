using Arrow.DeveloperTest.Application.Interfaces;
using Arrow.DeveloperTest.Application.Services;
using Arrow.DeveloperTest.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Arrow.DeveloperTest.Runner.Api.Controllers
{
    /// <summary>
    /// the payment controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        /// <summary>
        /// the payment service
        /// </summary>
        private readonly IPaymentService paymentService;

        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="paymentService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        [HttpPost("MakePayment")]
        public ActionResult MakePayment(MakePaymentRequest request)
        {
            try
            {
                var paymentResult = paymentService.MakePayment(request);

                if (paymentResult.Success)
                {
                    return Ok("Payment successful!");
                }
                else
                {
                    return BadRequest("Payment failed!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
