using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services.chatGPT;
using Fekra_DataAccessLayer.models.chatGPT;
using Fekra_DataAccessLayer.models.firebase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net.Http;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DhaferController : ControllerBase
    {
        private readonly GptService _gptService;

        public DhaferController(IHttpClientFactory httpClientFactory, IOptions<md_ChatGptConfig> gptConfig)
        {
            _gptService = new GptService(gptConfig.Value, httpClientFactory);
        }

        [HttpPost("GetResponseFromGPT", Name = "GetResponseFromGPT")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetResponseFromGPT([FromBody] string userInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    return BadRequest(new ApiResponse(false, "المدخلات غير صالحة", null));
                }

                // استدعاء الدالة من GptService
                var gptResponse = await _gptService.GetResponseFromGptAsync(userInput);

                if (string.IsNullOrEmpty(gptResponse))
                {
                    return StatusCode(500, new ApiResponse(false, "لم يتمكن النظام من استخراج الإجابة.", null));
                }

                return Ok(new ApiResponse(true, "تم الحصول على إجابة من GPT", new { response = gptResponse }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(false, "حدث خطأ أثناء معالجة الطلب.", new { message = ex.Message }));
            }
        }

    }

}
