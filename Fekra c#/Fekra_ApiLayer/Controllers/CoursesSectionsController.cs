using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Courses_Sections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesSectionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetCoursesSectionsByCourse/{courseId}", Name = "GetCoursesSectionsByCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetCoursesSectionsByCourseAsync(int courseId)
        {
            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            try
            {
                List<md_CoursesSections>? sections = await cls_CoursesSections.GetSectionsByCourseAsync(courseId);

                if (sections == null)
                    return NotFound(new ApiResponse(true, "Not courses sections found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Sections = sections,
                                count = sections.Count
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
        [HttpGet("GetCourseSectionById/{sectionId}", Name = "GetCourseSectionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetCourseSectionByIdAsync(int sectionId)
        {
            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            try
            {
                md_CourseSection? section = await cls_CoursesSections.GetByIdAsync(sectionId);

                if (section == null)
                    return NotFound(new ApiResponse(true, "Section not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Section = section
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
        [HttpDelete("DeleteCourseSection/{sectionId}/{byAdmin}", Name = "DeleteCourseSection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteCourseSectionAsync([FromRoute] int sectionId, [FromRoute] int byAdmin)
        {

            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_CoursesSections.DeleteAsync(sectionId, byAdmin);
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
                            "Please verify the section ID and byAdmin.",
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
        [HttpPatch("DeleteCourseSectionCover/{sectionId}/{byAdmin}", Name = "DeleteCourseSectionCover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteCourseSectionCoverAsync([FromRoute] int sectionId, [FromRoute] int byAdmin)
        {

            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_CoursesSections.DeleteCoverAsync(sectionId, byAdmin);
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
                            "Please verify the section ID and byAdmin.",
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
        [HttpGet("IsCourseSectionHasRelations/{sectionId}", Name = "IsCourseSectionHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsCourseSectionHasRelationsAsync([FromRoute] int sectionId)
        {
            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            try
            {
                bool response = await cls_CoursesSections.IsHasRelationsAsync(sectionId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            response ? "True." : "False.",
                            new
                            {
                                Response = response
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
        [HttpGet("IsCourseSectionCoverNameExist/{coverName}", Name = "IsCourseSectionCoverNameExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsCourseSectionCoverNameExistAsync([FromRoute] string coverName)
        {
            if (string.IsNullOrEmpty(coverName) || coverName.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid cover name (max length: 150).", new { }));

            try
            {
                bool isExist = await cls_CoursesSections.IsCoverExistAsync(coverName);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Cover name already exists." : "Cover name does not exist.",
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
        [HttpPatch("SetCourseSectionCover", Name = "SetCourseSectionCover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetCourseSectionCoverAsync([FromHeader] int sectionId, [FromHeader] string imageURL, [FromHeader] string imageName, [FromHeader] int byAdmin)
        {

            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            if (string.IsNullOrEmpty(imageURL))
                return BadRequest(new ApiResponse(false, "Invalid image URL.", new { }));

            if (!Validation.CheckLength(1, 150, imageName))
                return BadRequest(new ApiResponse(false, "Invalid image name.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_CoursesSections.SetCoverAsync(sectionId, imageURL, imageName, byAdmin);
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
                            "Please verify the section ID and image name and byAdmin.",
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
        [HttpPatch("SetCourseSectionName/{sectionId}/{sectionName}/{byAdmin}", Name = "SetCourseSectionName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetCourseSectionNameAsync([FromRoute] int sectionId, [FromRoute] string sectionName, [FromRoute] int byAdmin)
        {
            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            if (!Validation.CheckLength(1, 250, sectionName))
                return BadRequest(new ApiResponse(false, "Invalid section name.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_CoursesSections.SetSectionNameAsync(sectionId, sectionName, byAdmin);
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
                            "Please verify the section ID and byAdmin.",
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
        [HttpPost("NewCourseSection", Name = "NewCourseSection")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewCourseSectionAsync([FromBody] md_NewCourseSection section)
        {
            if (!cls_CoursesSections.ValidateObj_NewMode(section))
                return BadRequest(new ApiResponse(false, "Invalid course section data", new { }));

            try
            {
                int insertedId = await cls_CoursesSections.NewAsync(section);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Course section doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetCourseSectionById",
                        new
                        {
                            sectionId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Course section inserted successfully.",
                            new
                            {
                                Section = await cls_CoursesSections.GetByIdAsync(insertedId)
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
