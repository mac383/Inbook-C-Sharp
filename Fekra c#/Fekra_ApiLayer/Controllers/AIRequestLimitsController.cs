using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIRequestLimitsController : ControllerBase
    {
        [HttpGet("CheckIfLimitExists", Name = "CheckIfLimitExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CheckIfLimitExistsAsync([FromHeader] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid UserId.", new { Success = false }));

            try
            {
                bool exists = await cls_AIRequestLimits.CheckIfLimitExistsAsync(userId);

                return Ok
                (
                    new ApiResponse
                    (
                        true,
                        "Success",
                        new
                        {
                            LimitExists = exists
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
                        new { Success = false }
                    )
                );
            }
        }

        [HttpPost("ResetLimit", Name = "ResetLimit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> ResetLimitAsync([FromHeader] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid UserId.", new { Success = false }));

            try
            {
                bool success = await cls_AIRequestLimits.ResetLimitAsync(userId);

                if (!success)
                    return StatusCode(500, new ApiResponse(false, "Failed to reset limit.", new { Success = success }));

                return Ok
                (
                    new ApiResponse
                    (
                        true,
                        "Limit reset successfully.",
                        new { Success = success }
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
                        new { Success = false }
                    )
                );
            }
        }

        [HttpPost("DecrementRemainingRequests", Name = "DecrementRemainingRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DecrementRemainingRequestsAsync([FromHeader] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid UserId.", new { Success = false }));

            try
            {
                bool success = await cls_AIRequestLimits.DecrementRemainingRequestsAsync(userId);

                if (!success)
                    return StatusCode(500, new ApiResponse(false, "Failed to decrement remaining requests.", new { Success = success }));

                return Ok
                (
                    new ApiResponse
                    (
                        true,
                        "Request decremented successfully.",
                        new { Success = success }
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
                        new { Success = false }
                    )
                );
            }
        }

        [HttpGet("GetRemainingRequests", Name = "GetRemainingRequests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetRemainingRequestsAsync([FromHeader] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid UserId.", new { Success = false }));

            try
            {
                int remainingRequests = await cls_AIRequestLimits.GetRemainingRequestsAsync(userId);

                return Ok
                (
                    new ApiResponse
                    (
                        true,
                        "Success",
                        new
                        {
                            RemainingRequests = remainingRequests
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
                        new { Success = false }
                    )
                );
            }
        }
    }
}
