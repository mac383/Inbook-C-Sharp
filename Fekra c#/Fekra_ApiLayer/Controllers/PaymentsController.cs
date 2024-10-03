using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetTotalPayments", Name = "GetTotalPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTotalPaymentsAsync()
        {
            try
            {
                double payments = await cls_Payments.GetTotalPaymentsAsync();

                if (payments < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Payments = payments
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetPaymentsPagesCountAll", Name = "GetPaymentsPagesCountAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPaymentsPagesCountAllAsync()
        {
            try
            {
                int count = await cls_Payments.GetPaymentsPagesCountAllAsync();

                if (count < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Count = count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetAllPayments", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllPaymentsAsync()
        {
            try
            {
                List<md_Payments>? payments = await cls_Payments.GetAllAsync();

                if (payments == null)
                    return NotFound(new ApiResponse(true, "Not payments found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Payments = payments,
                                count = payments.Count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetPaymentsByUser/{userId}", Name = "GetPaymentsByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPaymentsByUserAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                List<md_Payments>? payments = await cls_Payments.GetByUserAsync(userId);

                if (payments == null)
                    return NotFound(new ApiResponse(true, "Not payments found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Payments = payments,
                                count = payments.Count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetPaymentById/{paymentId}", Name = "GetPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPaymentByIdAsync(int paymentId)
        {
            if (paymentId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid payment ID.", new { }));

            try
            {
                md_Payments? payment = await cls_Payments.GetByIdAsync(paymentId);

                if (payment == null)
                    return NotFound(new ApiResponse(true, "Payment not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Payment = payment,
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpPost("NewPayment", Name = "NewPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewPaymentAsync([FromBody] md_NewPayment payment)
        {
            if (!cls_Payments.ValidateObj_NewMode(payment))
                return BadRequest(new ApiResponse(false, "Invalid payment data", new { }));

            try
            {
                int insertedId = await cls_Payments.NewAsync(payment);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Payment doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetPaymentById",
                        new
                        {
                            paymentId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Payment inserted successfully.",
                            new
                            {
                                Payment = await cls_Payments.GetByIdAsync(insertedId)
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }
    }
}
