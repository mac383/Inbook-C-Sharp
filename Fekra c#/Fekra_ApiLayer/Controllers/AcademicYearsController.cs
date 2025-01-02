using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.AcademicYears;
using Fekra_DataAccessLayer.models.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearsController : ControllerBase
    {
        // completed testing.
        [Auth]
        [HttpGet("GetAcademicYearsCount", Name = "GetAcademicYearsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcademicYearsCountAsync()
        {
            try
            {
                int count = await cls_AcademicYears.GetCountAsync();

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
        [HttpGet("GetAllAcademicYears", Name = "GetAllAcademicYears")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllAcademicYearsAsync()
        {
            try
            {
                List<md_AcademicYears>? years = await cls_AcademicYears.GetAllAsync();

                if (years == null)
                    return NotFound(new ApiResponse(true, "Not academic years found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcademicYears = years,
                                count = years.Count
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
        [HttpGet("GetAcademicYearById/{yearId}", Name = "GetAcademicYearById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcademicYearByIdAsync(int yearId)
        {
            if (yearId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid academic year ID.", new { }));

            try
            {
                md_AcademicYears? year = await cls_AcademicYears.GetByIdAsync(yearId);

                if (year == null)
                    return NotFound(new ApiResponse(true, "Academic year not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcademicYear = year
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
        [HttpDelete("DeleteAcademicYear/{yearId}/{byAdmin}", Name = "DeleteAcademicYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteAcademicYearAsync([FromRoute] int yearId, [FromRoute] int byAdmin)
        {

            if (yearId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid academic year ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_AcademicYears.DeleteAsync(yearId, byAdmin);
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
                            "Please verify the academic year ID and byAdmin.",
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
        [HttpGet("IsAcademicYearHasRelations/{yearId}", Name = "IsAcademicYearHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsAcademicYearHasRelationsAsync([FromRoute] int yearId)
        {
            if (yearId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid academic year ID.", new { }));

            try
            {
                bool isHasRelations = await cls_AcademicYears.IsHasRelationsAsync(yearId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "The academic year has relations." : "The academic year does not has relations.",
                            new
                            {
                                HasRelations = isHasRelations
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
        [HttpGet("IsAcademicYearExist/{year}", Name = "IsAcademicYearExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsAcademicYearExistAsync([FromRoute] string year)
        {
            if (string.IsNullOrEmpty(year) || year.Length > 25)
                return BadRequest(new ApiResponse(false, "Invalid academic year (max length: 25).", new { }));

            try
            {
                bool isExist = await cls_AcademicYears.IsExistAsync(year);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Academic year already exists." : "Academic year does not exist.",
                            new
                            {
                                IsExist = isExist
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
        [HttpPost("NewAcademicYear", Name = "NewAcademicYear")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewAcademicYearAsync([FromBody] md_NewAcademicYear year)
        {
            if (!cls_AcademicYears.ValidateObj_NewMode(year))
                return BadRequest(new ApiResponse(false, "Invalid academic year data", new { }));

            try
            {
                int insertedId = await cls_AcademicYears.NewAsync(year);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Academic year doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetAcademicYearById",
                        new
                        {
                            yearId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Academic year inserted successfully.",
                            new
                            {
                                AcademicYear = await cls_AcademicYears.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateAcademicYear", Name = "UpdateAcademicYear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateAcademicYearAsync([FromBody] md_UpdateAcademicYear year)
        {
            if (!cls_AcademicYears.ValidateObj_UpdateMode(year))
                return BadRequest(new ApiResponse(false, "Invalid academic year data", new { }));

            try
            {
                bool response = await cls_AcademicYears.UpdateAsync(year);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Academic year doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Academic year updated successfully.", new { }));
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
