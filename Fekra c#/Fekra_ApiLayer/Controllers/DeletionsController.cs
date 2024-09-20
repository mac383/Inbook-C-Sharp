using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Deletions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletionsController : ControllerBase
    {

        // completed testing.
        [HttpGet("GetAllDeletions/{pageNumber}", Name = "GetAllDeletions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllDeletionsAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Deletions>? deletions = await cls_Deletions.GetAllAsync(pageNumber);

                if (deletions == null)
                    return NotFound(new ApiResponse(true, "Not deletions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Deletions = deletions,
                                count = deletions.Count
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
        [HttpGet("GetDeletionsByAdmin/{adminId}/{pageNumber}", Name = "GetDeletionsByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsByAdminAsync([FromRoute] int adminId, [FromRoute] int pageNumber)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Deletions>? deletions = await cls_Deletions.GetByAdminAsync(adminId, pageNumber);

                if (deletions == null)
                    return NotFound(new ApiResponse(true, "Not deletions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Deletions = deletions,
                                count = deletions.Count
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
        [HttpGet("GetDeletionsByTable/{tableId}/{pageNumber}", Name = "GetDeletionsByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsByTableAsync([FromRoute] int tableId, [FromRoute] int pageNumber)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Deletions>? deletions = await cls_Deletions.GetByTableAsync(tableId, pageNumber);

                if (deletions == null)
                    return NotFound(new ApiResponse(true, "Not deletions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Deletions = deletions,
                                count = deletions.Count
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
        [HttpGet("GetDeletionById/{deletionId}", Name = "GetDeletionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionByIdAsync([FromRoute] int deletionId)
        {
            if (deletionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid deletion ID.", new { }));

            try
            {
                md_Deletions? deletion = await cls_Deletions.GetByIdAsync(deletionId);

                if (deletion == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Deletion = deletion
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
        [HttpGet("GetDeletionsCount", Name = "GetDeletionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsCountAsync()
        {
            try
            {
                int _count = await cls_Deletions.GetCountAsync();
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetDeletionsPagesCountByAdmin/{adminId}", Name = "GetDeletionsPagesCountByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsPagesCountByAdminAsync(int adminId)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                int _count = await cls_Deletions.GetPagesCount_Admin_Async(adminId);
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetDeletionsPagesCount_All", Name = "GetDeletionsPagesCount_All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsPagesCount_All_Async()
        {
            try
            {
                int _count = await cls_Deletions.GetPagesCount_All_Async();
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetDeletionsPagesCountByTable/{tableId}", Name = "GetDeletionsPagesCountByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionsPagesCountByTableAsync(int tableId)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            try
            {
                int _count = await cls_Deletions.GetPagesCount_Table_Async(tableId);
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
