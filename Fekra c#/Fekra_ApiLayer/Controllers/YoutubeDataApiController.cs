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
        [HttpGet("IsPlaylistUrlExist", Name = "IsPlaylistUrlExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsPlaylistUrlExistAsync([FromHeader] string url)
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
        [HttpGet("ExtractPlaylistId", Name = "ExtractPlaylistId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> ExtractPlaylistIdAsync([FromHeader] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest(new ApiResponse(false, "URL can't be null.", new { }));

            try
            {
                string? response = cls_YoutubeDataApiService.ExtractPlaylistId(url);

                if (response == null)
                    return BadRequest(new ApiResponse(true, "Playlist Id does not extracted successfully.", new { Response = false }));

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

        // completed testing. 
        [HttpGet("ExtractVideoId", Name = "ExtractVideoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> ExtractVideoIdAsync([FromHeader] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest(new ApiResponse(false, "URL can't be null.", new { }));

            try
            {
                string? response = cls_YoutubeDataApiService.ExtractVideoId(url);

                if (response == null)
                    return BadRequest(new ApiResponse(true, "Video Id does not extracted successfully.", new { Response = false }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Video Id extracted successfully.",
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
