using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        [Auth]
        [HttpPost("HashSHA", Name = "HashSHA")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> HashSHAAsync([FromBody] string plainText)
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
                return StatusCode(
                    500,
                    new ApiResponse(
                        false,
                        "An error occurred while processing your request.",
                        new { response = false }
                    )
                );
            }
        }


        [HttpGet("Encrypt", Name = "Encrypt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> Encrypt([FromHeader] string plainText)
        {
            try
            {
                byte[] data = Convert.FromBase64String(plainText);
                plainText = Encoding.UTF8.GetString(data);

                if (string.IsNullOrEmpty(plainText))
                    return BadRequest(new ApiResponse(false, "Invalid plainText: The input cannot be empty or whitespace.", new { response = false }));

                string cipher = Encryption.SymmetricEncrypt(plainText);

                if (!string.IsNullOrEmpty(cipher))
                    return Ok(new ApiResponse(true, "The plain text was encrypted successfully.", new { response = true, Cipher = cipher }));

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

        [HttpGet("Decrypt", Name = "Decrypt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> Decrypt([FromHeader] string cipher)
        {
            try
            {
                byte[] data = Convert.FromBase64String(cipher);
                cipher = Encoding.UTF8.GetString(data);

                if (string.IsNullOrEmpty(cipher))
                    return BadRequest(new ApiResponse(false, "Invalid cipherText: The input cannot be empty or whitespace.", new { response = false }));

                string plain = Encryption.SymmetricDecrypt(cipher);

                if (!string.IsNullOrEmpty(plain))
                    return Ok(new ApiResponse(true, "The cipher text was decrypted successfully.", new { response = true, Plain = plain }));

                else
                    return BadRequest(new ApiResponse(false, "Failed to decrypt the cipher text. Please try again.", new { response = false }));

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
