using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeDataApiController : ControllerBase
    {
        // completed testing.
        [HttpGet("IsPlaylistUrlExist/{url}", Name = "IsPlaylistUrlExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsPlaylistUrlExistAsync([FromRoute] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest(new ApiResponse(false, "URL can't be null.", new { }));

            try
            {
                bool response = await cls_YoutubeDataApiService.CheckPlaylistExists(url);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            response ? "True." : "False.",
                            new
                            {
                                Response = response
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
        [HttpGet("ExtractPlaylistId/{url}", Name = "ExtractPlaylistId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> ExtractPlaylistId([FromRoute] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest(new ApiResponse(false, "URL can't be null.", new { }));

            try
            {
                string? response = cls_YoutubeDataApiService.ExtractPlaylistId(url);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Playlist Id extracted successfully.",
                            new
                            {
                                Response = response
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
