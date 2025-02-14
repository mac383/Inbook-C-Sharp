using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_BusinessLayer.Utils.Notifications;
using Fekra_DataAccessLayer.models.Admins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpGet("SendRegistrationConfirmationEmail/{to}/{username}", Name = "SendRegistrationConfirmationEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SendRegistrationConfirmationEmail(string to, string username)
        {
            if (!Validation.IsEmailValid(to))
                return BadRequest(new ApiResponse(false, "Invalid email.", new { }));

            if (!Validation.IsUsernameValid(username))
                return BadRequest(new ApiResponse(false, "Invalid username.", new { }));

            try
            {
                NotificationService notification = new NotificationService(new EmailService());

                string? response = await notification.SendEmailByInfibip(to, username, NotificationService.EN_MessageType.RegistrationConfirmation);

                if (response == null)
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

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                VirificationCode = response
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

        [HttpGet("SendPasswordResetConfirmationEmail/{to}/{username}", Name = "SendPasswordResetConfirmationEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SendPasswordResetConfirmationEmail(string to, string username)
        {
            if (!Validation.IsEmailValid(to))
                return BadRequest(new ApiResponse(false, "Invalid email.", new { }));

            if (!Validation.IsUsernameValid(username))
                return BadRequest(new ApiResponse(false, "Invalid username.", new { }));

            try
            {
                NotificationService notification = new NotificationService(new EmailService());

                string? response = await notification.SendEmailByInfibip(to, username, NotificationService.EN_MessageType.PasswordResetConfirmation);

                if (response == null)
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

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                VirificationCode = response
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

        [HttpGet("SendEmailVerification/{to}/{username}", Name = "SendEmailVerification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SendEmailVerification(string to, string username)
        {
            if (!Validation.IsEmailValid(to))
                return BadRequest(new ApiResponse(false, "Invalid email.", new { }));

            if (!Validation.IsUsernameValid(username))
                return BadRequest(new ApiResponse(false, "Invalid username.", new { }));

            try
            {
                NotificationService notification = new NotificationService(new EmailService());

                string? response = await notification.SendEmailByInfibip(to, username, NotificationService.EN_MessageType.EmailVerification);

                if (response == null)
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

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                VirificationCode = response
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
