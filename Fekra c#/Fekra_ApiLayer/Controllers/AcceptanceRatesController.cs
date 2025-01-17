using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Acceptance_Rates;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptanceRatesController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAcceptanceRatesCount", Name = "GetAcceptanceRatesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRatesCountAsync()
        {
            try
            {
                int count = await cls_AcceptanceRates.GetCountAsync();

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
        [HttpGet("GetAcceptanceRatesCountByBranch/{branchId}", Name = "GetAcceptanceRatesCountByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRatesCountByBranchAsync([FromRoute] int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                int count = await cls_AcceptanceRates.GetCountByBranchAsync(branchId);

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
        [HttpGet("GetAcceptanceRatesPagesCountByBranch/{branchId}", Name = "GetAcceptanceRatesPagesCountByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRatesPagesCountByBranchAsync([FromRoute] int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                int count = await cls_AcceptanceRates.GetPagesCountByBranchAsync(branchId);

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
        [HttpGet("GetAcceptanceRatesByBranch/{branchId}/{pageNumber}", Name = "GetAcceptanceRatesByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRatesByBranchAsync(int branchId, int pageNumber)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_AcceptanceRates>? rates = await cls_AcceptanceRates.GetByBranchAsync(branchId, pageNumber);

                if (rates == null)
                    return NotFound(new ApiResponse(true, "Not acceptance rates found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcceptanceRates = rates,
                                count = rates.Count
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
        [HttpGet("GetAcceptanceRatesByAverage/{average}", Name = "GetAcceptanceRatesByAverage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRatesByAverageAsync(decimal average)
        {
            if (average <= 0)
                return BadRequest(new ApiResponse(false, "Invalid average.", new { }));

            try
            {
                List<md_AcceptanceRates>? rates = await cls_AcceptanceRates.GetByAverageAsync(average);

                if (rates == null)
                    return NotFound(new ApiResponse(true, "Not acceptance rates found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcceptanceRates = rates,
                                count = rates.Count
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
        [HttpGet("GetAcceptanceRateById/{rateId}", Name = "GetAcceptanceRateById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]    
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRateByIdAsync(int rateId)
        {
            if (rateId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid rate ID.", new { }));

            try
            {
                md_AcceptanceRates? rate = await cls_AcceptanceRates.GetByIdAsync(rateId);

                if (rate == null)
                    return NotFound(new ApiResponse(true, "Acceptance rate not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcceptanceRate = rate
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
        [HttpDelete("DeleteAcceptanceRate/{rateId}/{byAdmin}", Name = "DeleteAcceptanceRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteAcceptanceRateAsync([FromRoute] int rateId, [FromRoute] int byAdmin)
        {

            if (rateId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_AcceptanceRates.DeleteAsync(rateId, byAdmin);
                if (response)
                    return Ok
                        (
                            new ApiResponse
                            (
                                true,
                                "Success.",
                                new { Response = response }
                            )
                        );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            true,
                            "Please verify the acceptance rate ID and byAdmin.",
                            new { Response = response }
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
        [HttpPost("NewAcceptanceRate", Name = "NewAcceptanceRate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewAcceptanceRateAsync([FromBody] md_NewAcceptanceRate rate)
        {
            if (!cls_AcceptanceRates.ValidateObj_NewMode(rate))
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate data", new { }));

            try
            {
                int insertedId = await cls_AcceptanceRates.NewAsync(rate);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Acceptance rate doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetAcceptanceRateById",
                        new
                        {
                            rateId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Acceptance rate inserted successfully.",
                            new
                            {
                                AcceptanceRate = await cls_AcceptanceRates.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateAcceptanceRate", Name = "UpdateAcceptanceRate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateAcceptanceRateAsync([FromBody] md_UpdateAcceptanceRate rate)
        {
            if (!cls_AcceptanceRates.ValidateObj_UpdateMode(rate))
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate data", new { }));

            try
            {
                bool response = await cls_AcceptanceRates.UpdateAsync(rate);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Acceptance rate doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Acceptance rate updated successfully.", new { }));
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
