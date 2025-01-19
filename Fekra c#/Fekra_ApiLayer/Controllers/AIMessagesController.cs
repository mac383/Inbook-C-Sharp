using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.classes;
using Fekra_DataAccessLayer.models.AI_Messages;
using Fekra_DataAccessLayer.models.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIMessagesController : ControllerBase
    {
        [HttpPost("HandleMessage", Name = "HandleMessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> HandleMessageAsync([FromBody] md_NewMessage newMessage)
        {
            if (!cls_AIMessages.ValidateObj_NewMode(newMessage))
                return BadRequest(new ApiResponse(false, "Invalid input data.", new { Success = false }));

            try
            {
                bool success = await cls_AIMessages.HandleMessageAsync(newMessage);

                if (!success)
                    return StatusCode(500, new ApiResponse(false, "Failed to add the message.", new { Success = false }));

                return Ok(new ApiResponse(true, "Message added successfully.", new { Success = success }));
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                    (
                        () => newMessage.ConversationId,
                        () => newMessage.Request,
                        () => newMessage.Response,
                        () => newMessage.Summary
                    );

                // تسجيل الخطأ
                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "API Layer",
                    ex.Source ?? "null",
                    "AIMessagesController",
                    "HandleMessageAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { Success = false }));
            }
        }

        [HttpGet("GetMessagesByConversation", Name = "GetMessagesByConversation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetMessagesByConversationAsync([FromHeader] int conversationId)
        {
            if (conversationId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid ConversationId.", new { Success = false }));

            try
            {
                var messages = await cls_AIMessages.GetMessagesByConversationAsync(conversationId);

                if (messages == null || messages.Count == 0)
                    return NotFound(new ApiResponse(false, "No messages found for this conversation.", new { Success = false }));

                return Ok(new ApiResponse(true, "Success", new { Messages = messages }));
            }
            catch (Exception ex)
            {
                string Params = cls_Errors_D.GetParams
                (
                    () => conversationId
                );

                // تسجيل الخطأ
                await cls_Errors_D.LogErrorAsync(new md_NewError
                (
                    ex.Message,
                    "API Layer",
                    ex.Source ?? "null",
                    "AIMessagesController",
                    "GetMessagesByConversationAsync",
                    ex.StackTrace ?? "null",
                    null,
                    Params
                ));

                return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { Success = false }));
            }
        }
    }
}
