using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Enrolled_Lessons;
using Fekra_DataAccessLayer.models.Enrolled_Sections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledLessonsController : ControllerBase
    {
        // completed testing.
        [Auth]
        [HttpGet("GetEnrolledLessonsByEnrolledSection/{enrolledSectionId}", Name = "GetEnrolledLessonsByEnrolledSection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledLessonsByEnrolledSectionAsync(int enrolledSectionId)
        {
            if (enrolledSectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled section ID.", new { }));

            try
            {
                List<md_EnrolledLessons>? enrolledLessons = await cls_EnrolledLessons.GetByEnrolledSectionAsync(enrolledSectionId);

                if (enrolledLessons == null)
                    return NotFound(new ApiResponse(true, "Not enrolled lessons found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                EnrolledLessons = enrolledLessons,
                                count = enrolledLessons.Count
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
        [Auth]
        [HttpGet("GetEnrolledLessonById/{enrolledLessonId}", Name = "GetEnrolledLessonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledLessonByIdAsync([FromRoute] int enrolledLessonId)
        {
            if (enrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            try
            {
                md_EnrolledLesson? enrolledLesson = await cls_EnrolledLessons.GetByIdAsync(enrolledLessonId);

                if (enrolledLesson == null)
                    return NotFound(new ApiResponse(true, "Enrolled lesson not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                EnrolledLesson = enrolledLesson
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
        [Auth]
        [HttpPatch("DeleteEnrolledLessonFile/{enrolledLessonId}", Name = "DeleteEnrolledLessonFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteEnrolledLessonFileAsync([FromRoute] int enrolledLessonId)
        {
            if (enrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            try
            {
                bool response = await cls_EnrolledLessons.DeleteFileAsync(enrolledLessonId);
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
                            "Please verify the enrolled lesson ID.",
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
        [Auth]
        [HttpPatch("DeleteEnrolledLessonNote/{enrolledLessonId}", Name = "DeleteEnrolledLessonNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteEnrolledLessonNoteAsync([FromRoute] int enrolledLessonId)
        {
            if (enrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            try
            {
                bool response = await cls_EnrolledLessons.DeleteNoteAsync(enrolledLessonId);
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
                            "Please verify the enrolled lesson ID.",
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
        [HttpGet("IsEnrolledLessonFileExist/{fileName}", Name = "IsEnrolledLessonFileExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsEnrolledLessonFileExistAsync([FromRoute] string fileName)
        {
            if (!Validation.CheckLength(1, 150, fileName))
                return BadRequest(new ApiResponse(false, "Invalid file name (max length: 150).", new { }));

            try
            {
                bool isExist = await cls_EnrolledLessons.IsFileExistAsync(fileName);
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
        [Auth]
        [HttpPatch("SetEnrolledLessonAsCompleted/{enrolledLessonId}", Name = "SetEnrolledLessonAsCompleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledLessonAsCompleted([FromRoute] int enrolledLessonId)
        {
            if (enrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            try
            {
                bool response = await cls_EnrolledLessons.SetAsCompletedAsync(enrolledLessonId);
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
                            "Please verify the enrolled lesson ID.",
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
        [Auth]
        [HttpPost("SetEnrolledLessonFile", Name = "SetEnrolledLessonFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledLessonFileAsync([FromBody] md_newLessonFile request)
        {

            if (request.EnrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            if (string.IsNullOrEmpty(request.FileURL))
                return BadRequest(new ApiResponse(false, "Invalid file URL.", new { }));

            if (!Validation.CheckLength(1, 150, request.FileName))
                return BadRequest(new ApiResponse(false, "Invalid file name.", new { }));

            if (!Validation.CheckLength(1, 250, request.FileTitle))
                return BadRequest(new ApiResponse(false, "Invalid file title.", new { }));

            try
            {
                bool response = await cls_EnrolledLessons.SetFileAsync(request.EnrolledLessonId, request.FileTitle, request.FileURL, request.FileName);
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
                            "Please verify the enrolled lesson ID and file name.",
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
        [Auth]
        [HttpPatch("SetEnrolledLessonNote/{enrolledLessonId}/{note}", Name = "SetEnrolledLessonNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetEnrolledLessonNoteAsync([FromRoute] int enrolledLessonId, [FromRoute] string note)
        {
            if (enrolledLessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled lesson ID.", new { }));

            if (!Validation.CheckLength(1, 250, note))
                return BadRequest(new ApiResponse(false, "Invalid  note (max length: 250).", new { }));

            try
            {
                bool response = await cls_EnrolledLessons.SetNoteAsync(enrolledLessonId, note);
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
                            "Please verify the enrolled lesson ID.",
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
