using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Enrolled_Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledCoursesController : ControllerBase
    {
        //completed testing.
        [Auth]
        [HttpGet("GetEnrolledCoursesByUser/{userId}", Name = "GetEnrolledCoursesByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledCoursesByUserAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                List<md_EnrolledCourses>? courses = await cls_EnrolledCourses.GetByUserAsync(userId);

                if (courses == null)
                    return NotFound(new ApiResponse(true, "Not enrolled courses found.", new { }));

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

        //completed testing.
        [Auth]
        [HttpGet("GetEnrolledCourseById/{enrolledCourseId}", Name = "GetEnrolledCourseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetEnrolledCourseByIdAsync(int enrolledCourseId)
        {
            if (enrolledCourseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled course ID.", new { }));

            try
            {
                md_EnrolledCourse? course = await cls_EnrolledCourses.GetByIdAsync(enrolledCourseId);

                if (course == null)
                    return NotFound(new ApiResponse(true, "Enrolled course not found.", new { }));

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

        //completed testing.
        [Auth]
        [HttpDelete("DeleteEnrolledCourse/{enrolledCourseId}", Name = "DeleteEnrolledCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteEnrolledCourseAsync([FromRoute] int enrolledCourseId)
        {
            if (enrolledCourseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid enrolled course ID.", new { }));

            try
            {
                bool response = await cls_EnrolledCourses.DeleteAsync(enrolledCourseId);
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
                            "Please verify the enrolled course ID.",
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
        [HttpGet("IsUserEnrolledToCourse/{userId}/{courseId}", Name = "IsUserEnrolledToCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsUserEnrolledToCourseAsync([FromRoute] int userId, [FromRoute] int courseId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (courseId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid course ID.", new { }));

            try
            {
                bool isEnrolled = await cls_EnrolledCourses.IsUserEnrolledToCourseAsync(userId, courseId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isEnrolled ? "True." : "False.",
                            new
                            {
                                Response = isEnrolled
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
        [HttpPost("NewEnrolledCourse", Name = "NewEnrolledCourse")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewEnrolledCourseAsync([FromBody] md_NewEnrolledCourse enrolledCourse)
        {
            if (!cls_EnrolledCourses.ValidateObj_NewMode(enrolledCourse))
                return BadRequest(new ApiResponse(false, "Invalid enrolled course data", new { }));

            try
            {
                int insertedId = await cls_EnrolledCourses.NewAsync(enrolledCourse);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Course doesn't enrolled successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetEnrolledCourseById",
                        new
                        {
                            enrolledCourseId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Course enrolled successfully.",
                            new
                            {
                                EnrolledCourse = await cls_EnrolledCourses.GetByIdAsync(insertedId)
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
