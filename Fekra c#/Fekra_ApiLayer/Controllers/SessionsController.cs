using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Sessions;
using Fekra_DataAccessLayer.models.System_Tables;
using Fekra_DataAccessLayer.models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetActiveSessions/{pageNumber}", Name = "GetActiveSessions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveSessionsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Sessions>? sessions = await cls_Sessions.GetActiveSessionsAsync(pageNumber);

                if (sessions == null)
                    return NotFound(new ApiResponse(true, "Not sessions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Sessions = sessions,
                                count = sessions.Count
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
        [HttpGet("GetInActiveSessions/{pageNumber}", Name = "GetInActiveSessions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActiveSessionsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Sessions>? sessions = await cls_Sessions.GetInActiveSessionsAsync(pageNumber);

                if (sessions == null)
                    return NotFound(new ApiResponse(true, "Not sessions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Sessions = sessions,
                                count = sessions.Count
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
        [HttpGet("GetActiveSessionKey/{userId}", Name = "GetActiveSessionKey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveSessionKeyAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                string? key = await cls_Sessions.GetActiveSessionKeyAsync(userId);

                if (key == null)
                    return NotFound(new ApiResponse(true, "Active key not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Key = key
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
        [HttpGet("GetActiveSessionsCount", Name = "GetActiveSessionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveSessionsCountAsync()
        {
            try
            {
                int count = await cls_Sessions.GetActivesCountAsync();

                if (count < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Count = count
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
        [HttpGet("GetInActiveSessionsCount", Name = "GetInActiveSessionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActiveSessionsCountAsync()
        {
            try
            {
                int count = await cls_Sessions.GetInActivesCountAsync();

                if (count < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Count = count
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
        [HttpGet("GetSessionsPageCountActive", Name = "GetSessionsPageCountActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetSessionsPageCountActiveAsync()
        {
            try
            {
                int count = await cls_Sessions.GetSessionsPagesCountActivesAsync();

                if (count < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Count = count
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
        [HttpGet("GetSessionsPageCountInActive", Name = "GetSessionsPageCountInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetSessionsPageCountInActiveAsync()
        {
            try
            {
                int count = await cls_Sessions.GetSessionsPagesCountInActivesAsync();

                if (count < 0)
                    return StatusCode(500, new ApiResponse(false, "An error occurred while processing your request.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Count = count
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
        [HttpDelete("DeleteInActiveSessions", Name = "DeleteInActiveSessions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteInActiveSessionsAsync()
        {
            try
            {
                bool response = await cls_Sessions.DeleteInActiveSessionsAsync();
                if (response)
                    return Ok
                        (
                            new ApiResponse
                            (
                                true,
                                "Success.",
                                new { Response = response }
                            )
                        );

                int sessionsCount = await cls_Sessions.GetInActivesCountAsync();

                if (sessionsCount > 0)
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

                return BadRequest
                    (
                        new ApiResponse
                        (
                            true,
                            "There are no inactive sessions.",
                            new { Response = response }
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
        [HttpGet("IsSessionKeyActive/{sessionKey}", Name = "IsSessionKeyActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsSessionKeyActiveAsync([FromRoute] string sessionKey)
        {
            if (string.IsNullOrEmpty(sessionKey) || sessionKey.Length > 100)
                return BadRequest(new ApiResponse(false, "Invalid session key (max length: 100).", new { }));

            try
            {
                bool isActive = await cls_Sessions.IsSessionKeyActiveAsync(sessionKey);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isActive ? "Key is active." : "Key is not active.",
                            new
                            {
                                IsActive = isActive
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
        [HttpGet("IsSessionKeyExist/{sessionKey}", Name = "IsSessionKeyExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsSessionKeyExistAsync([FromRoute] string sessionKey)
        {
            if (string.IsNullOrEmpty(sessionKey) || sessionKey.Length > 100)
                return BadRequest(new ApiResponse(false, "Invalid session key (max length: 100).", new { }));

            try
            {
                bool isExist = await cls_Sessions.IsSessionKeyExistAsync(sessionKey);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isExist ? "Key is exist." : "Key is not exist.",
                            new
                            {
                                IsExist = isExist
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
        [HttpPost("NewSession", Name = "NewSession")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewSessionAsync([FromBody] md_NewSession session)
        {
            if (!cls_Sessions.ValidateObj_NewMode(session))
                return BadRequest(new ApiResponse(false, "Invalid session data", new { }));

            try
            {
                int insertedId = await cls_Sessions.NewAsync(session);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Session doesn't inserted successfully.", new { }));

                return Ok(new ApiResponse(true, "Session inserted successfully.", new {}));
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
        [HttpPatch("SetSessionAsInActive/{userId}", Name = "SetSessionAsInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetSessionAsInActiveAsync([FromRoute] int userId)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                bool response = await cls_Sessions.SetSessionAsInActiveAsync(userId);
                if (response)
                    return Ok
                        (
                            new ApiResponse
                            (
                                true,
                                "Success.",
                                new { Response = response }
                            )
                        );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            true,
                            "Please verify the user ID.",
                            new { Response = response }
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
        [HttpGet("GetUserSessionsAnalytics/{userId}", Name = "GetUserSessionsAnalytics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUserSessionsAnalyticsAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                var (TotalSessions, ActiveSessions, InActiveSessions) = await cls_Sessions.GetUserSessionsAnalyticsAsync(userId);

                if (TotalSessions >= 0)
                {
                    return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                TotalSessions,
                                ActiveSessions,
                                InActiveSessions
                            }
                        )
                    );
                }
                else
                {
                    return BadRequest(new ApiResponse(false, "Error retrieving session data.", new { }));
                }
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
                        new { Error = ex.Message }
                    )
                );
            }
        }

        // completed testing.
        [HttpGet("GetUsersSessionsAnalytics", Name = "GetUsersSessionsAnalytics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersSessionsAnalyticsAsync()
        {
            try
            {
                var (TotalSessions, ActiveSessions, InActiveSessions) = await cls_Sessions.GetUsersSessionsAnalyticsAsync();

                if (TotalSessions >= 0)
                {
                    return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                TotalSessions,
                                ActiveSessions,
                                InActiveSessions
                            }
                        )
                    );
                }
                else
                {
                    return BadRequest(new ApiResponse(false, "Error retrieving sessions data.", new { }));
                }
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
                        new { Error = ex.Message }
                    )
                );
            }
        }

    }
}
