using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Enrolled_Sections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledSectionsController : ControllerBase
    {
        //completed testing.
        [Auth]
        [HttpGet("GetEnrolledSectionsByEnrolledCourse/{enrolledCourseId}", Name = "GetEnrolledSectionsByEnrolledCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledSectionsByEnrolledCourseAsync(int enrolledCourseId)
        {
            if (enrolledCourseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled course ID.", new { }));

            try
            {
                List<md_EnrolledSections>? enrolledSections = await cls_EnrolledSections.GetByEnrolledCourseAsync(enrolledCourseId);

                if (enrolledSections == null)
                    return NotFound(new ApiResponse(true, "Not enrolled courses found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                EnrolledCourses = enrolledSections,
                                count = enrolledSections.Count
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

        //completed testing.
        [Auth]
        [HttpGet("GetEnrolledSectionById/{enrolledSectionId}", Name = "GetEnrolledSectionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledSectionByIdAsync(int enrolledSectionId)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            try
            {
                md_EnrolledSection? enrolledSection = await cls_EnrolledSections.GetByIdAsync(enrolledSectionId);

                if (enrolledSection == null)
                    return NotFound(new ApiResponse(true, "Enrolled section not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                EnrolledSection = enrolledSection
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

        //completed testing.
        [Auth]
        [HttpPatch("DeleteEnrolledSectionFile/{enrolledSectionId}", Name = "DeleteEnrolledSectionFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteEnrolledSectionFileAsync([FromRoute] int enrolledSectionId)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            try
            {
                bool response = await cls_EnrolledSections.DeleteFileAsync(enrolledSectionId);
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
                            "Please verify the enrolled section ID.",
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

        //completed testing.
        [HttpGet("IsEnrolledSectionFileExist/{fileName}", Name = "IsEnrolledSectionFileExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsEnrolledSectionFileExistAsync([FromRoute] string fileName)
        {
            if (!Validation.CheckLength(1, 150, fileName))
                return BadRequest(new ApiResponse(false, "Invalid file name (max length: 150).", new { }));

            try
            {
                bool isExist = await cls_EnrolledSections.IsFileExistAsync(fileName);
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

        //completed testing.
        [HttpGet("IsEnrolledSectionStarted/{enrolledSectionId}", Name = "IsEnrolledSectionStarted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsEnrolledSectionStartedAsync([FromRoute] int enrolledSectionId)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            try
            {
                bool isStarted = await cls_EnrolledSections.IsSectionStartedAsync(enrolledSectionId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isStarted ? "Enrolled section is started." : "Enrolled section does not started.",
                            new
                            {
                                Response = isStarted
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

        //completed testing.
        [Auth]
        [HttpPatch("SetEnrolledSectionAsStarted/{enrolledSectionId}", Name = "SetEnrolledSectionAsStarted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledSectionAsStartedAsync([FromRoute] int enrolledSectionId)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            try
            {
                bool response = await cls_EnrolledSections.SetAsStartedAsync(enrolledSectionId);
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
                            "Please verify the enrolled section ID.",
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

        //completed testing.
        [Auth]
        [HttpPost("SetEnrolledSectionFile", Name = "SetEnrolledSectionFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledSectionFileAsync([FromBody] md_newFile request)
        {

            if (request.EnrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            if (string.IsNullOrEmpty(request.FileURL))
                return BadRequest(new ApiResponse(false, "Invalid file URL.", new { }));

            if (!Validation.CheckLength(1, 150, request.FileName))
                return BadRequest(new ApiResponse(false, "Invalid file name.", new { }));

            if (!Validation.CheckLength(1, 250, request.FileTitle))
                return BadRequest(new ApiResponse(false, "Invalid file title.", new { }));

            try
            {
                bool response = await cls_EnrolledSections.SetFileAsync(request.EnrolledSectionId, request.FileTitle, request.FileURL, request.FileName);
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
                            "Please verify the enrolled section ID and file name.",
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

        //completed testing.
        [Auth]
        [HttpPatch("SetEnrolledSectionFileTitle/{enrolledSectionId}/{fileTitle}", Name = "SetEnrolledSectionFileTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledSectionFileTitleAsync([FromRoute] int enrolledSectionId, [FromRoute] string fileTitle)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            if (!Validation.CheckLength(1, 250, fileTitle))
                return BadRequest(new ApiResponse(false, "Invalid file title.", new { }));

            try
            {
                bool response = await cls_EnrolledSections.SetFileTitleAsync(enrolledSectionId, fileTitle);
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
                            "Please verify the enrolled section ID and file title.",
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
    }
}
