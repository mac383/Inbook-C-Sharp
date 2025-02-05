using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_DataAccessLayer.models.firebase;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3ConfigController : ControllerBase
    {
        private readonly md_s3Config _s3Config;

        public S3ConfigController(IOptions<md_s3Config> s3Config)
        {
            _s3Config = s3Config.Value;
        }


        [Auth]
        [HttpGet("GetS3Config", Name = "GetS3Config")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> GetS3Config()
        {
            try
            {
                if (_s3Config == null)
                {
                    return NotFound(new ApiResponse(false, "فشل في تحميل إعدادات s3", new { }));
                }

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "تم تحميل إعدادات s3 بنجاح",
                            new
                            {
                                accessKeyId = _s3Config.AccessKeyId,
                                secretAccessKey = _s3Config.SecretAccessKey,
                                region = _s3Config.Region
                            }
                        )
                    );
            }
            catch (Exception ex)
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { message = ex.Message }
                        )
                    );
            }
        }
    }
}
