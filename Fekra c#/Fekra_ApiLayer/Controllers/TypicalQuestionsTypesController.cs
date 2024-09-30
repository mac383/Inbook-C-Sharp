using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Typical_Questions_Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypicalQuestionsTypesController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllTypicalQuestionsTypes", Name = "GetAllTypicalQuestionsTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllTypicalQuestionsTypesAsync()
        {
            try
            {
                List<md_TypicalQuestionsTypes>? types = await cls_TypicalQuestionsTypes.GetAllAsync();

                if (types == null)
                    return NotFound(new ApiResponse(true, "Not typical questions types found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Types = types,
                                count = types.Count
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
        [HttpGet("GetTypicalQuestionTypeById/{typeId}", Name = "GetTypicalQuestionTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTypicalQuestionTypeByIdAsync(int typeId)
        {
            if (typeId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid type ID.", new { }));

            try
            {
                md_TypicalQuestionsTypes? type = await cls_TypicalQuestionsTypes.GetByIdAsync(typeId);

                if (type == null)
                    return NotFound(new ApiResponse(true, "Typical question type not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Type = type
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
        [HttpDelete("DeleteTypicalQuestionType/{typeId}/{byAdmin}", Name = "DeleteTypicalQuestionType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteTypicalQuestionTypeAsync([FromRoute] int typeId, [FromRoute] int byAdmin)
        {

            if (typeId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid type ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_TypicalQuestionsTypes.DeleteAsync(typeId, byAdmin);
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
                            "Please verify the type ID and byAdmin.",
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
        [HttpGet("IsTypicalQuestionTypeHasRelations/{typeId}", Name = "IsTypicalQuestionTypeHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsTypicalQuestionTypeHasRelationsAsync([FromRoute] int typeId)
        {
            if (typeId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid type ID.", new { }));

            try
            {
                bool isHasRelations = await cls_TypicalQuestionsTypes.IsHasRelationsAsync(typeId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "The typical question type has relations." : "The typical question type does not has relations.",
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
        [HttpGet("IsTypicalQuestionTypeExist/{type}", Name = "IsTypicalQuestionTypeExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsTypicalQuestionTypeExistAsync([FromRoute] string type)
        {
            if (string.IsNullOrEmpty(type) || type.Length > 25)
                return BadRequest(new ApiResponse(false, "Invalid typical question type (max length: 25).", new { }));

            try
            {
                bool isExist = await cls_TypicalQuestionsTypes.IsExistAsync(type);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Typical question type already exists." : "Typical question type does not exist.",
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
        [HttpPost("NewTypicalQuestionType", Name = "NewTypicalQuestionType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewTypicalQuestionTypeAsync([FromBody] md_NewTypicalQuestionType type)
        {
            if (!cls_TypicalQuestionsTypes.ValidateObj_NewMode(type))
                return BadRequest(new ApiResponse(false, "Invalid typical question type data", new { }));

            try
            {
                int insertedId = await cls_TypicalQuestionsTypes.NewAsync(type);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Typical question type doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetTypicalQuestionTypeById",
                        new
                        {
                            typeId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Typical question type inserted successfully.",
                            new
                            {
                                Type = await cls_TypicalQuestionsTypes.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateTypicalQuestionType", Name = "UpdateTypicalQuestionType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateTypicalQuestionTypeAsync([FromBody] md_UpdateTypicalQuestionType type)
        {
            if (!cls_TypicalQuestionsTypes.ValidateObj_UpdateMode(type))
                return BadRequest(new ApiResponse(false, "Invalid typical question type data", new { }));

            try
            {
                bool response = await cls_TypicalQuestionsTypes.UpdateAsync(type);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Typical question type doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Typical question type updated successfully.", new { }));
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
