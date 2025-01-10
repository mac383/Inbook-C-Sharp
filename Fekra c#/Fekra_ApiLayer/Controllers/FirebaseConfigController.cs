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
    public class FirebaseConfigController : ControllerBase
    {
        private readonly md_FirebaseConfig _firebaseConfig;

        public FirebaseConfigController(IOptions<md_FirebaseConfig> firebaseConfig)
        {
            _firebaseConfig = firebaseConfig.Value;
        }


        [Auth]
        [HttpGet("GetFirebaseConfig", Name = "GetFirebaseConfig")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ApiResponse> GetFirebaseConfig()
        {
            try
            {
                if (_firebaseConfig == null)
                {
                    return NotFound(new ApiResponse(false, "فشل في تحميل إعدادات Firebase", new { }));
                }

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "تم تحميل إعدادات Firebase بنجاح",
                            new
                            {
                                ApiKey = _firebaseConfig.ApiKey,
                                AuthDomain = _firebaseConfig.AuthDomain,
                                ProjectId = _firebaseConfig.ProjectId,
                                StorageBucket = _firebaseConfig.StorageBucket,
                                MessagingSenderId = _firebaseConfig.MessagingSenderId,
                                AppId = _firebaseConfig.AppId,
                                MeasurementId = _firebaseConfig.MeasurementId
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
