using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Acceptance_Rates_Files;
using Fekra_DataAccessLayer.models.Branches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptanceRatesFilesController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllAcceptanceRatesFiles", Name = "GetAllAcceptanceRatesFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllAcceptanceRatesFilesAsync()
        {
            try
            {
                List<md_AcceptanceRatesFiles>? files = await cls_AcceptanceRatesFiles.GetAllAsync();

                if (files == null)
                    return NotFound(new ApiResponse(true, "Not acceptance rates files found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcceptanceRatesFiles = files,
                                count = files.Count
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
        [HttpGet("GetAcceptanceRateFileById/{fileId}", Name = "GetAcceptanceRateFileById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAcceptanceRateFileByIdAsync(int fileId)
        {
            if (fileId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate file ID.", new { }));

            try
            {
                md_AcceptanceRatesFiles? file = await cls_AcceptanceRatesFiles.GetByIdAsync(fileId);

                if (file == null)
                    return NotFound(new ApiResponse(true, "Acceptance rate file not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                AcceptanceRateFile = file
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
        [HttpDelete("DeleteAcceptanceRateFile/{fileId}/{byAdmin}", Name = "DeleteAcceptanceRateFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteAcceptanceRateFileAsync([FromRoute] int fileId, [FromRoute] int byAdmin)
        {

            if (fileId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate file ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_AcceptanceRatesFiles.DeleteAsync(fileId, byAdmin);
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
                            "Please verify the acceptance rate file ID and byAdmin.",
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
        [HttpGet("IsAcceptanceRatesFilesFileNameExist/{fileName}", Name = "IsAcceptanceRatesFilesFileNameExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsAcceptanceRatesFilesFileNameExistAsync([FromRoute] string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid file name (max length: 150).", new { }));

            try
            {
                bool isExist = await cls_AcceptanceRatesFiles.IsFileExistAsync(fileName);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "File name already exists." : "File name does not exist.",
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
        [HttpPost("NewAcceptanceRateFile", Name = "NewAcceptanceRateFile")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewAcceptanceRateFileAsync([FromBody] md_NewAcceptanceRateFile file)
        {
            if (!cls_AcceptanceRatesFiles.ValidateObj_NewMode(file))
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate file data", new { }));

            try
            {
                int insertedId = await cls_AcceptanceRatesFiles.NewAsync(file);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Acceptance rate file doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetAcceptanceRateFileById",
                        new
                        {
                            fileId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Acceptance rate file inserted successfully.",
                            new
                            {
                                AcceptanceRateFile = await cls_AcceptanceRatesFiles.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateAcceptanceRateFile", Name = "UpdateAcceptanceRateFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateAcceptanceRateFileAsync([FromBody] md_UpdateAcceptanceRateFile file)
        {
            if (!cls_AcceptanceRatesFiles.ValidateObj_UpdateMode(file))
                return BadRequest(new ApiResponse(false, "Invalid acceptance rate file data", new { }));

            try
            {
                bool response = await cls_AcceptanceRatesFiles.UpdateAsync(file);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Acceptance rate file doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Acceptance rate file updated successfully.", new { }));
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
