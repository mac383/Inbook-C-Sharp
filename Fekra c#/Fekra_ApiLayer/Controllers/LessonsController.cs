using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetLessonsBySection/{sectionId}", Name = "GetLessonsBySection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetLessonsBySectionAsync(int sectionId)
        {
            if (sectionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid section ID.", new { }));

            try
            {
                List<md_Lessons>? lessons = await cls_Lessons.GetBySectionAsync(sectionId);

                if (lessons == null)
                    return NotFound(new ApiResponse(true, "Not lessons found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Lessons = lessons,
                                count = lessons.Count
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
        [HttpDelete("DeleteLesson/{lessonId}/{byAdmin}", Name = "DeleteLesson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteLessonAsync([FromRoute] int lessonId, [FromRoute] int byAdmin)
        {

            if (lessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid lesson ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Lessons.DeleteAsync(lessonId, byAdmin);
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
                            "Please verify the lesson ID and byAdmin.",
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
        [HttpPatch("UpdateLessonTitle/{lessonId}/{title}/{byAdmin}", Name = "UpdateLessonTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateLessonTitleAsync([FromRoute] int lessonId, [FromRoute] string title, [FromRoute] int byAdmin)
        {

            if (lessonId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid lesson ID.", new { }));

            if (!Validation.CheckLength(1, 250, title))
                return BadRequest(new ApiResponse(false, "Invalid title.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Lessons.UpdateTitleAsync(lessonId, title, byAdmin);
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
                            "Please verify the lesson ID and byAdmin.",
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
        [HttpPost("NewLesson", Name = "NewLesson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewLessonAsync([FromBody] md_NewLesson lesson)
        {
            if (!cls_Lessons.ValidateObj_NewMode(lesson))
                return BadRequest(new ApiResponse(false, "Invalid lesson data", new { }));

            try
            {
                int insertedId = await cls_Lessons.NewAsync(lesson);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Lesson doesn't inserted successfully.", new { }));

                return Ok(new ApiResponse(true, "Lesson inserted successfully.", new{ }));
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
