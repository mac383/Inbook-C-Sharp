using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllBranches", Name = "GetAllBranches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllBranchesAsync()
        {
            try
            {
                List<md_Branches>? branches = await cls_Branches.GetAllAsync();

                if (branches == null)
                    return NotFound(new ApiResponse(true, "Not branches found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Branches = branches,
                                count = branches.Count
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
        [HttpGet("GetBranchById/{branchId}", Name = "GetBranchById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetBranchByIdAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                md_Branches? branch = await cls_Branches.GetByIdAsync(branchId);

                if (branch == null)
                    return NotFound(new ApiResponse(true, "Branch not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Branch = branch
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
        [HttpDelete("DeleteBranch/{branchId}/{byAdmin}", Name = "DeleteBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteBranchAsync([FromRoute] int branchId, [FromRoute] int byAdmin)
        {

            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Branches.DeleteAsync(branchId, byAdmin);
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
                            "Please verify the branch ID and byAdmin.",
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
        [HttpGet("IsBranchExist/{branchName}", Name = "IsBranchExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsBranchExistAsync([FromRoute] string branchName)
        {
            if (string.IsNullOrEmpty(branchName) || branchName.Length > 50)
                return BadRequest(new ApiResponse(false, "Invalid branch name (max length: 50).", new { }));

            try
            {
                bool isExist = await cls_Branches.IsBranchExistAsync(branchName);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Branch name already exists." : "Branch name does not exist.",
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
        [HttpGet("IsBranchHasRelations/{branchId}", Name = "IsBranchHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsBranchHasRelationsAsync([FromRoute] int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                bool isHasRelations = await cls_Branches.IsHasRelationsAsync(branchId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "The branch has relations." : "The branch does not has relations.",
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
        [HttpPost("NewBranch", Name = "NewBranch")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewBranchAsync([FromBody] md_NewBranch branch)
        {
            if (!cls_Branches.ValidateObj_NewMode(branch))
                return BadRequest(new ApiResponse(false, "Invalid branch data", new { }));

            try
            {
                int insertedId = await cls_Branches.NewAsync(branch);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Branch doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetBranchById",
                        new
                        {
                            branchId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Branch inserted successfully.",
                            new
                            {
                                Branch = await cls_Branches.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateBranch", Name = "UpdateBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateBranchAsync([FromBody] md_UpdateBranch branch)
        {
            if (!cls_Branches.ValidateObj_UpdateMode(branch))
                return BadRequest(new ApiResponse(false, "Invalid branch data", new { }));

            try
            {
                bool response = await cls_Branches.UpdateAsync(branch);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Branch doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Branch updated successfully.", new { }));
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
