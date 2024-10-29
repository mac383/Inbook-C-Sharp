using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {

        [HttpGet("HashSHA/{plainText}", Name = "HashSHA")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> HashSHAAsync([FromRoute] string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return BadRequest(new ApiResponse(false, "Invalid plainText: The input cannot be empty or whitespace.", new { response = false }));

            try
            {
                string hash = Encryption.HashEncrypt(plainText);

                if (!string.IsNullOrEmpty(hash))
                    return Ok(new ApiResponse(true, "The plain text was encrypted successfully.", new { response = true, Hash = hash }));

                else
                    return BadRequest(new ApiResponse(false, "Failed to encrypt the plain text. Please try again.", new { response = false }));

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
                            new { response = false }
                        )
                    );
            }
        }

    }
}
