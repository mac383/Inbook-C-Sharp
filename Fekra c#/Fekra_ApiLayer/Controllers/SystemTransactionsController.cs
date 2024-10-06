using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Additions;
using Fekra_DataAccessLayer.models.SystemTransactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemTransactionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetTransactionsByTarget/{targetId}/{tableName}", Name = "GetTransactionsByTarget")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetTransactionsByTargetAsync([FromRoute] int targetId, string tableName)
        {
            if (targetId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid target ID.", new { }));

            try
            {
                List<md_SystemTransactions>? transactions = await cls_SystemTransactions.GetByTarget(targetId, tableName);

                if (transactions == null)
                    return NotFound(new ApiResponse(true, "Not transactions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Transactions = transactions,
                                count = transactions.Count
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
