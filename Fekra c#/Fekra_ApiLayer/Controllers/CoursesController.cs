using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetCoursesCount", Name = "GetCoursesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetCoursesCountAsync()
        {
            try
            {
                int count = await cls_Courses.GetCountAsync();

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
        [HttpGet("GetActiveCoursesCount", Name = "GetActiveCoursesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveCoursesCountAsync()
        {
            try
            {
                int count = await cls_Courses.GetActivesCountAsync();

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
        [HttpGet("GetInActiveCoursesCount", Name = "GetInActiveCoursesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActiveCoursesCountAsync()
        {
            try
            {
                int count = await cls_Courses.GetInActivesCountAsync();

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
        [HttpGet("GetActiveCoursesByBranch/{branchId}", Name = "GetActiveCoursesByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveCoursesByBranchAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_ActiveCourses>? courses = await cls_Courses.GetActivesByBranchAsync(branchId);

                if (courses == null)
                    return NotFound(new ApiResponse(true, "Not courses found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Courses = courses,
                                count = courses.Count
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
        [HttpGet("GetAllCoursesByBranch/{branchId}", Name = "GetAllCoursesByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllCoursesByBranchAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_Courses>? courses = await cls_Courses.GetAllByBranchAsync(branchId);

                if (courses == null)
                    return NotFound(new ApiResponse(true, "Not courses found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Courses = courses,
                                count = courses.Count
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
        [HttpGet("GetCourseById/{courseId}", Name = "GetCourseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetCourseByIdAsync(int courseId)
        {
            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            try
            {
                md_Courses? course = await cls_Courses.GetByIdAsync(courseId);

                if (course == null)
                    return NotFound(new ApiResponse(true, "Course not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Course = course
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
        [HttpGet("IsCourseHasRelations/{courseId}", Name = "IsCourseHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsCourseHasRelationsAsync([FromRoute] int courseId)
        {
            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            try
            {
                bool isHasRelations = await cls_Courses.IsCourseHasRelationsAsync(courseId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "True." : "False.",
                            new
                            {
                                Response = isHasRelations
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
        [HttpGet("IsCourseCoverExist/{coverName}", Name = "IsCourseCoverExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsCourseCoverExistAsync([FromRoute] string coverName)
        {
            if (!Validation.CheckLength(1, 150, coverName))
                return BadRequest(new ApiResponse(false, "Invalid cover name.", new { }));

            try
            {
                bool isExist = await cls_Courses.IsCoverExistAsync(coverName);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Cover name already exist." : "Cover name does not exist.",
                            new
                            {
                                Response = isExist
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
        [HttpPatch("SetCourseAsActive/{courseId}/{byAdmin}", Name = "SetCourseAsActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetCourseAsActiveAsync([FromRoute] int courseId, [FromRoute] int byAdmin)
        {

            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Courses.SetAsActiveAsync(courseId, byAdmin);
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
                            "Please verify the course ID and byAdmin.",
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
        [HttpPatch("SetCourseAsInActive/{courseId}/{byAdmin}", Name = "SetCourseAsInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetCourseAsInActiveAsync([FromRoute] int courseId, [FromRoute] int byAdmin)
        {

            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Courses.SetAsInActiveAsync(courseId, byAdmin);
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
                            "Please verify the course ID and byAdmin.",
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
        [HttpPatch("SetCourseCover/{courseId}/{imageURL}/{imageName}/{byAdmin}", Name = "SetCourseCover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetCourseCoverAsync([FromRoute] int courseId, [FromRoute] string imageURL, [FromRoute] string imageName, [FromRoute] int byAdmin)
        {

            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (string.IsNullOrEmpty(imageURL))
                return BadRequest(new ApiResponse(false, "Invalid image URL.", new { }));

            if (!Validation.CheckLength(1, 150, imageName))
                return BadRequest(new ApiResponse(false, "Invalid image name.", new { }));
            
            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Courses.SetCoverAsync(courseId, imageURL, imageName, byAdmin);
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
                            "Please verify the course Id and admin ID and image name.",
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
        [HttpDelete("DeleteCourse/{courseId}/{byAdmin}", Name = "DeleteCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteCourseAsync([FromRoute] int courseId, [FromRoute] int byAdmin)
        {

            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Courses.DeleteAsync(courseId, byAdmin);
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
                            "Please verify the course ID and byAdmin.",
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
        [HttpPatch("DeleteCourseCover/{courseId}/{byAdmin}", Name = "DeleteCourseCover")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteCourseCoverAsync([FromRoute] int courseId, [FromRoute] int byAdmin)
        {
            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Courses.DeleteCourseCoverAsync(courseId, byAdmin);
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
                            "Please verify the course ID and byAdmin.",
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
        [HttpPost("NewCourse", Name = "NewCourse")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewCourseAsync([FromBody] md_NewCourse course)
        {
            if (!cls_Courses.ValidateObj_NewMode(course))
                return BadRequest(new ApiResponse(false, "Invalid course data", new { }));

            try
            {
                int insertedId = await cls_Courses.NewAsync(course);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Course doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetCourseById",
                        new
                        {
                            courseId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Course inserted successfully.",
                            new
                            {
                                Course = await cls_Courses.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateCourse", Name = "UpdateCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateCourseAsync([FromBody] md_UpdateCourse course)
        {
            if (!cls_Courses.ValidateObj_UpdateMode(course))
                return BadRequest(new ApiResponse(false, "Invalid course data", new { }));

            try
            {
                bool response = await cls_Courses.UpdateAsync(course);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Course doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Course updated successfully.", new { }));
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
