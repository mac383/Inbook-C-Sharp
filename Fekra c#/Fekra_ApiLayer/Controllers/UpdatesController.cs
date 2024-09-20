using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Deletions;
using Fekra_DataAccessLayer.models.Updates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {

        // completed testing.
        [HttpGet("GetAllUpdates/{pageNumber}", Name = "GetAllUpdates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllUpdatesAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Updates>? updates = await cls_Updates.GetAllAsync(pageNumber);

                if (updates == null)
                    return NotFound(new ApiResponse(true, "Not updates found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Updates = updates,
                                count = updates.Count
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
        [HttpGet("GetUpdatesByAdmin/{adminId}/{pageNumber}", Name = "GetUpdatesByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesByAdminAsync([FromRoute] int adminId, [FromRoute] int pageNumber)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Updates>? updates = await cls_Updates.GetByAdminAsync(adminId, pageNumber);

                if (updates == null)
                    return NotFound(new ApiResponse(true, "Not updates found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Updates = updates,
                                count = updates.Count
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
        [HttpGet("GetUpdatesByTable/{tableId}/{pageNumber}", Name = "GetUpdatesByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesByTableAsync([FromRoute] int tableId, [FromRoute] int pageNumber)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Updates>? updates = await cls_Updates.GetByTableAsync(tableId, pageNumber);

                if (updates == null)
                    return NotFound(new ApiResponse(true, "Not updates found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Updates = updates,
                                count = updates.Count
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
        [HttpGet("GetUpdateById/{updateId}", Name = "GetUpdateById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdateByIdAsync([FromRoute] int updateId)
        {
            if (updateId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid update ID.", new { }));

            try
            {
                md_Updates? update = await cls_Updates.GetByIdAsync(updateId);

                if (update == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Update = update
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
        [HttpGet("GetUpdatesCount", Name = "GetUpdatesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesCountAsync()
        {
            try
            {
                int _count = await cls_Updates.GetCountAsync();
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
        [HttpGet("GetUpdatesPagesCountByAdmin/{adminId}", Name = "GetUpdatesPagesCountByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesPagesCountByAdminAsync(int adminId)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                int _count = await cls_Updates.GetPagesCount_Admin_Async(adminId);
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
        [HttpGet("GetUpdatesPagesCount_All", Name = "GetUpdatesPagesCount_All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesPagesCount_All_Async()
        {
            try
            {
                int _count = await cls_Updates.GetPagesCount_All_Async();
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
        [HttpGet("GetUpdatesPagesCountByTable/{tableId}", Name = "GetUpdatesPagesCountByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUpdatesPagesCountByTableAsync(int tableId)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            try
            {
                int _count = await cls_Updates.GetPagesCount_Table_Async(tableId);
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
