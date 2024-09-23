using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_DataAccessLayer.models.System_Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemTablesController : ControllerBase
    {

        // completed testing.
        [HttpDelete("DeleteTable/{tableId}/{byAdmin}", Name = "DeleteTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteTableAsync([FromRoute] int tableId, [FromRoute] int byAdmin)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                bool response = await cls_SystemTables.DeleteAsync(tableId, byAdmin);
                if (response)
                    return Ok
                    (
                        new ApiResponse
                        (
                            response,
                            "Success, Table deleted successfully.",
                            new { }
                        )
                    );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            response,
                            "Table not deleted, Please verify the table ID, admin ID and ensure that the table does not have any links to other data.",
                            new { }
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
        [HttpGet("IsHasRelations/{tableId}", Name = "IsHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsHasRelationsAsync([FromRoute] int tableId)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            try
            {
                bool hasRelations = await cls_SystemTables.IsHasRelations(tableId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            hasRelations ? "Table has relations." : "Table hasn't relations.",
                            new
                            {
                                HasRelations = hasRelations
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
        [HttpGet("IsTableNameExist/{tableName}", Name = "IsTableNameExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsTableNameExistAsync([FromRoute] string tableName)
        {
            if (string.IsNullOrEmpty(tableName) || tableName.Length > 100)
                return BadRequest(new ApiResponse(false, "Invalid table Name (max length: 100).", new { }));

            try
            {
                bool isExist = await cls_SystemTables.IsTableNameExist(tableName);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Table name exist." : "Table name not exist.",
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
        [HttpPost("NewTable", Name = "NewTable")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewTableAsync([FromBody] md_NewTable table)
        {
            if (!cls_SystemTables.ValidateObj_NewMode(table))
                return BadRequest(new ApiResponse(false, "Invalid table data", new { }));

            try
            {
                int insertedId = await cls_SystemTables.NewAsync(table);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Table doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetTableById",
                        new
                        {
                            tableId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Table inserted successfully.",
                            new
                            {
                                Table = await cls_SystemTables.GetByIdAsync(insertedId)
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
        [HttpPut("UpdateTable", Name = "UpdateTable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateTableAsync([FromBody] md_UpdateTable table)
        {
            if (!cls_SystemTables.ValidateObj_UpdateMode(table))
                return BadRequest(new ApiResponse(false, "Invalid table data", new { }));

            try
            {
                bool isUpdated = await cls_SystemTables.UpdateAsync(table);

                if (!isUpdated)
                    return BadRequest(new ApiResponse(false, "Table doesn't updated successfully.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Table updated successfully.",
                            new
                            {
                                Table = await cls_SystemTables.GetByIdAsync(table.TableId)
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
        [HttpGet("GetAllTables", Name = "GetAllTables")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllTablesAsync()
        {
            try
            {
                List<md_SystemTables>? tables = await cls_SystemTables.GetAllAsync();

                if (tables == null)
                    return NotFound(new ApiResponse(true, "Not tables found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Tables = tables,
                                count = tables.Count
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
        [HttpGet("GetTableById/{tableId}", Name = "GetTableById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTableByIdAsync([FromRoute] int tableId)
        {
            if (tableId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid table ID.", new { }));

            try
            {
                md_SystemTables? table = await cls_SystemTables.GetByIdAsync(tableId);

                if (table == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Table = table
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
        [HttpGet("GetCount", Name = "GetCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetCountAsync()
        {
            try
            {
                int count = await cls_SystemTables.GetCountAsync();

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

    }
}
