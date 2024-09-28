using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.General_Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralQuestionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllGeneralQuestions", Name = "GetAllGeneralQuestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllGeneralQuestionsAsync()
        {
            try
            {
                List<md_GeneralQuestions>? questions = await cls_GeneralQuestions.GetAllAsync();

                if (questions == null)
                    return NotFound(new ApiResponse(true, "Not general questions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                GeneralQuestions = questions,
                                count = questions.Count
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
        [HttpGet("GetGeneralQuestionById/{questionId}", Name = "GetGeneralQuestionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetGeneralQuestionByIdAsync(int questionId)
        {
            if (questionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid question ID.", new { }));

            try
            {
                md_GeneralQuestions? question = await cls_GeneralQuestions.GetByIdAsync(questionId);

                if (question == null)
                    return NotFound(new ApiResponse(true, "General question not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                GeneralQuestion = question
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
        [HttpPost("NewGeneralQuestion", Name = "NewGeneralQuestion")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewGeneralQuestionAsync([FromBody] md_NewGeneralQuestion question)
        {
            if (!cls_GeneralQuestions.ValidateObj_NewMode(question))
                return BadRequest(new ApiResponse(false, "Invalid question data", new { }));

            try
            {
                int insertedId = await cls_GeneralQuestions.NewAsync(question);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "General question doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetGeneralQuestionById",
                        new
                        {
                            questionId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "General question inserted successfully.",
                            new
                            {
                                GeneralQuestion = await cls_GeneralQuestions.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateGeneralQuestion", Name = "UpdateGeneralQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateGeneralQuestionAsync([FromBody] md_UpdateGeneralQuestion question)
        {
            if (!cls_GeneralQuestions.ValidateObj_UpdateMode(question))
                return BadRequest(new ApiResponse(false, "Invalid question data", new { }));

            try
            {
                int rowsAffected = await cls_GeneralQuestions.UpdateAsync(question);

                if (rowsAffected <= 0)
                    return BadRequest(new ApiResponse(false, "General question doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "General question updated successfully.", new{ }));
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
        [HttpDelete("DeleteGeneralQuestion/{questionId}/{byAdmin}", Name = "DeleteGeneralQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteGeneralQuestionAsync([FromRoute] int questionId, [FromRoute] int byAdmin)
        {

            if (questionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid question ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_GeneralQuestions.DeleteAsync(questionId, byAdmin);
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
                            "Please verify the question ID and byAdmin.",
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
