using Arrow.DeveloperTest.Domain.Entities;
using Arrow.DeveloperTest.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Arrow.DeveloperTest.Application.Mapping
{
    public static class PaymentMappingExtensions
    {
        /// <summary>
        /// To map the MakePaymentRequest  to MakePaymentRequestDto
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MakePaymentResultDto ToDto(this MakePaymentResult result)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));

            return new MakePaymentResultDto
            {
                Success = result.Success
            };
        }
    }
}
