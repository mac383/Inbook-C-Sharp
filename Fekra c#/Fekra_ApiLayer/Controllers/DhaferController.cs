using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services.chatGPT;
using Fekra_DataAccessLayer.models.chatGPT;
using Fekra_DataAccessLayer.models.firebase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net.Http;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.AI_Messages;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.Errors;
using Fekra_ApiLayer.Common.JwtAuth;

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

        [Auth]
        [HttpPost("GetResponseFromGPT", Name = "GetResponseFromGPT")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetResponseFromGPTAsync([FromBody] md_ChatGptRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.UserInput))
                    return BadRequest(new ApiResponse(false, "المدخلات غير صالحة. UserInput مطلوب.", null));

                //string currentSummary = await cls_AIConversations.GetConversationSummaryAsync(request.ConversationId);
                string gptResponse = await _gptService.GetResponseFromGptAsync(request, "");

                if (string.IsNullOrEmpty(gptResponse))
                    return StatusCode(500, new ApiResponse(false, "حدث خطأ أثناء معالجة الطلب.", new { success = false }));

                _ = Task.Run(async () =>
                {
                    //string newSummary = await _gptService.GenerateSummaryAsync(currentSummary, request.UserInput, gptResponse);
                    await cls_AIMessages.HandleMessageAsync(new md_NewMessage(request.ConversationId, request.UserInput, gptResponse, "لا يتم تعيين ملخص حالياً."));
                });

                return Ok(new ApiResponse(true, "تم الحصول على إجابة من ظفر.", new { response = gptResponse }));
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => request.ConversationId,
                    () => request.UserInput,
                    () => request.UserFullName,
                    () => request.MemoryData,
                    () => request.Topic,
                    () => request.Branch
                );

                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "API Layer",
                    ex.Source ?? "null",
                    "DhaferController",
                    "GetResponseFromGPTAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return StatusCode(500, new ApiResponse(false, "حدث خطأ أثناء معالجة الطلب.", new { message = ex.Message }));
            }
        }
    }
}
