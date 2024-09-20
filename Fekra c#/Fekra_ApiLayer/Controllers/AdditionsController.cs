using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllAdditions/{pageNumber}", Name = "GetAllAdditions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllAdditionsAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Additions>? additions = await cls_Additions.GetAllAsync(pageNumber);

                if (additions == null)
                    return NotFound(new ApiResponse(true, "Not additions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Additions = additions,
                                count = additions.Count
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
        [HttpGet("GetAdditionsByAdmin/{adminId}/{pageNumber}", Name = "GetAdditionsByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsByAdminAsync([FromRoute] int adminId, [FromRoute] int pageNumber)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Additions>? additions = await cls_Additions.GetByAdminAsync(adminId, pageNumber);

                if (additions == null)
                    return NotFound(new ApiResponse(true, "Not additions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Additions = additions,
                                count = additions.Count
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
        [HttpGet("GetAdditionsByTable/{tableId}/{pageNumber}", Name = "GetAdditionsByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsByTableAsync([FromRoute] int tableId, [FromRoute] int pageNumber)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Additions>? additions = await cls_Additions.GetByTableAsync(tableId, pageNumber);

                if (additions == null)
                    return NotFound(new ApiResponse(true, "Not additions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Additions = additions,
                                count = additions.Count
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
        [HttpGet("GetAdditionById/{additionId}", Name = "GetAdditionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionByIdAsync([FromRoute] int additionId)
        {
            if (additionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid addition ID.", new { }));

            try
            {
                md_Additions? addition = await cls_Additions.GetByIdAsync(additionId);

                if (addition == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Addition = addition
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
        [HttpGet("GetAdditionsCount", Name = "GetAdditionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsCountAsync()
        {
            try
            {
                int _count = await cls_Additions.GetCountAsync();
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
        [HttpGet("GetAdditionsPagesCountByAdmin/{adminId}", Name = "GetAdditionsPagesCountByAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsPagesCountByAdminAsync(int adminId)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                int _count = await cls_Additions.GetPagesCount_Admin_Async(adminId);
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
        [HttpGet("GetAdditionsPagesCount_All", Name = "GetAdditionsPagesCount_All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsPagesCount_All_Async()
        {
            try
            {
                int _count = await cls_Additions.GetPagesCount_All_Async();
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
        [HttpGet("GetAdditionsPagesCountByTable/{tableId}", Name = "GetAdditionsPagesCountByTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdditionsPagesCountByTableAsync(int tableId)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            try
            {
                int _count = await cls_Additions.GetPagesCount_Table_Async(tableId);
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
