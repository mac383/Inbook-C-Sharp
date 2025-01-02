using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.AIUserMemory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIUserMemoryController : ControllerBase
    {
        [HttpPost("UpdateUserMemory", Name = "UpdateUserMemory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateUserMemoryAsync([FromBody] md_UpdateUserMemory updateData)
        {
            if (!cls_AIUserMemory.ValidateObj_UpdateMode(updateData))
                return BadRequest(new ApiResponse(false, "Invalid input data.", new { Success = false }));

            try
            {
                bool success = await cls_AIUserMemory.UpdateUserMemoryAsync(updateData);

                if (!success)
                    return StatusCode(500, new ApiResponse(false, "Failed to update user memory.", new { Success = false }));

                return Ok(new ApiResponse(true, "User memory updated successfully.", new { Success = success }));
            }
            catch
            {
                return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { Success = false }));
            }
        }

        [HttpGet("GetUserMemoryByUserId", Name = "GetUserMemoryByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUserMemoryByUserIdAsync([FromHeader] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid UserId.", new { Success = false }));

            try
            {
                md_UserMemory? memory = await cls_AIUserMemory.GetUserMemoryByUserIdAsync(userId);

                if (memory == null)
                    return NotFound(new ApiResponse(false, "User memory not found.", new { Success = false }));

                return Ok(new ApiResponse(true, "Success", new { UserMemory = memory }));
            }
            catch
            {
                return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { Success = false }));
            }
        }
    }
}
