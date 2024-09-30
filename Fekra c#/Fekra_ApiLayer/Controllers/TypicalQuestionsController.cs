using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Typical_Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypicalQuestionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetTypicalQuestionsPagesCountMaterials/{materialId}", Name = "GetTypicalQuestionsPagesCountMaterials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTypicalQuestionsPagesCountMaterialsAsync(int materialId)
        {
            if (materialId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid material ID.", new { }));

            try
            {
                int count = await cls_TypicalQuestions.GetTypicalQuestionsPagesCountMaterialsAsync(materialId);

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
        [HttpGet("GetTypicalQuestionById/{questionId}", Name = "GetTypicalQuestionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTypicalQuestionByIdAsync(int questionId)
        {
            if (questionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid typical question ID.", new { }));

            try
            {
                md_TypicalQuestion? question = await cls_TypicalQuestions.GetByIdAsync(questionId);

                if (question == null)
                    return NotFound(new ApiResponse(true, "Typical question not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                TypicalQuestion = question
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
        [HttpGet("GetByMaterial/{materialId}/{packageNumber}", Name = "GetByMaterial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetByMaterialAsync(int materialId, int packageNumber)
        {
            if (materialId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid material ID.", new { }));

            if (packageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid package number.", new { }));

            try
            {
                List<md_TypicalQuestion>? questions = await cls_TypicalQuestions.GetByMaterialAsync(materialId, packageNumber);

                if (questions == null)
                    return NotFound(new ApiResponse(true, "Not typical questions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                TypicalQuestions = questions,
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
        [HttpDelete("DeleteTypicalQuestion/{questionId}/{byAdmin}", Name = "DeleteTypicalQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteTypicalQuestionAsync([FromRoute] int questionId, [FromRoute] int byAdmin)
        {

            if (questionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid question ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_TypicalQuestions.DeleteAsync(questionId, byAdmin);
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

        // completed testing.
        [HttpGet("IsTypicalQuestionFileExist/{fileName}", Name = "IsTypicalQuestionFileExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsTypicalQuestionFileExistAsync([FromRoute] string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid file name (max length: 150).", new { }));

            try
            {
                bool isExist = await cls_TypicalQuestions.IsFileExistAsync(fileName);
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
        [HttpPost("NewTypicalQuestion", Name = "NewTypicalQuestion")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewTypicalQuestionAsync([FromBody] md_NewTypicalQuestion question)
        {
            if (!cls_TypicalQuestions.ValidateObj_NewMode(question))
                return BadRequest(new ApiResponse(false, "Invalid typical question data", new { }));

            try
            {
                int insertedId = await cls_TypicalQuestions.NewAsync(question);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Typical question doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetTypicalQuestionById",
                        new
                        {
                            questionId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Typical question inserted successfully.",
                            new
                            {
                                TypicalQuestion = await cls_TypicalQuestions.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateTypicalQuestion", Name = "UpdateTypicalQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateTypicalQuestionAsync([FromBody] md_UpdateTypicalQuestion question)
        {
            if (!cls_TypicalQuestions.ValidateObj_UpdateMode(question))
                return BadRequest(new ApiResponse(false, "Invalid typical question data", new { }));

            try
            {
                bool response = await cls_TypicalQuestions.UpdateAsync(question);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Typical question doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Typical question updated successfully.", new { }));
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
