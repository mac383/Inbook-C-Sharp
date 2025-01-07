using Fekra_ApiLayer.Common;
using Fekra_ApiLayer.Common.JwtAuth;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Users;
using Fekra_DataAccessLayer.models.Users_Subscriptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersSubscriptionsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetActiveUsersSubscriptionsCount", Name = "GetActiveUsersSubscriptionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveUsersSubscriptionsCountAsync()
        {
            try
            {
                int count = await cls_UsersSubscriptions.GetActivesCount();

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
        [HttpGet("GetUsersSubscriptionsCount", Name = "GetUsersSubscriptionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersSubscriptionsCountAsync()
        {
            try
            {
                int count = await cls_UsersSubscriptions.GetCountAsync();

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
        [HttpGet("GetInActiveUsersSubscriptionsCount", Name = "GetInActiveUsersSubscriptionsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActiveUsersSubscriptionsCountAsync()
        {
            try
            {
                int count = await cls_UsersSubscriptions.GetInActivesCountAsync();

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
        [HttpGet("GetUsersSubscriptionsPagesCountActive", Name = "GetUsersSubscriptionsPagesCountActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersSubscriptionsPagesCountActiveAsync()
        {
            try
            {
                int count = await cls_UsersSubscriptions.GetUsersSubscriptionsPagesCountActiveAsync();

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
        [HttpGet("GetUsersSubscriptionsPagesCountInActive", Name = "GetUsersSubscriptionsPagesCountInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersSubscriptionsPagesCountInActiveAsync()
        {
            try
            {
                int count = await cls_UsersSubscriptions.GetUsersSubscriptionsPagesCountInActivesAsync();

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
        [HttpGet("GetActivesUsersSubscriptions/{pageNumber}", Name = "GetActivesUsersSubscriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActivesUsersSubscriptionsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_UsersSubscriptions>? subscriptions = await cls_UsersSubscriptions.GetActivesAsync(pageNumber);

                if (subscriptions == null)
                    return NotFound(new ApiResponse(true, "Not subscriptions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Subscriptions = subscriptions,
                                count = subscriptions.Count
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
        [HttpGet("GetInActivesUsersSubscriptions/{pageNumber}", Name = "GetInActivesUsersSubscriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActivesUsersSubscriptionsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_UsersSubscriptions>? subscriptions = await cls_UsersSubscriptions.GetInActivesAsync(pageNumber);

                if (subscriptions == null)
                    return NotFound(new ApiResponse(true, "Not subscriptions found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Subscriptions = subscriptions,
                                count = subscriptions.Count
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
        [HttpGet("GetActiveUserSubscriptionByUser/{userId}", Name = "GetActiveUserSubscriptionByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActiveUserSubscriptionByUserAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                md_UserSubscription? subscription = await cls_UsersSubscriptions.GetActiveSubscriptionByUserAsync(userId);

                if (subscription == null)
                    return NotFound(new ApiResponse(true, "Subscription not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Subscriptions = subscription
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
        [HttpGet("GetSubscriptionById/{subscriptionId}", Name = "GetSubscriptionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetSubscriptionByIdAsync(int subscriptionId)
        {
            if (subscriptionId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid subscription ID.", new { }));

            try
            {
                md_UserSubscription? subscription = await cls_UsersSubscriptions.GetSubscriptionByIdAsync(subscriptionId);

                if (subscription == null)
                    return NotFound(new ApiResponse(true, "Subscription not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Subscriptions = subscription
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
        [HttpGet("CheckUserSubscription/{userId}", Name = "CheckUserSubscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CheckUserSubscriptionAsync([FromRoute] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                bool isActive = await cls_UsersSubscriptions.CheckUserSubscriptionAsync(userId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isActive ? "Subscription is active." : "Subscription does not active.",
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
        [HttpGet("CheckAllUsersSubscriptions", Name = "CheckAllUsersSubscriptions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CheckAllUsersSubscriptionsAsync()
        {
            try
            {
                bool isSuccessful = await cls_UsersSubscriptions.CheckAllUsersSubscriptionsAsync();

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isSuccessful ? "Subscriptions checked successfully." : "Subscriptions were not checked successfully.",
                            new
                            {
                                IsSuccessful = isSuccessful
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
        [HttpGet("IsUserHasActiveSubscription/{userId}", Name = "IsUserHasActiveSubscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsUserHasActiveSubscriptionAsync([FromRoute] int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                bool isHasActiveSubscription = await cls_UsersSubscriptions.IsUserHasActiveSubscriptionAsync(userId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasActiveSubscription ? "True." : "False.",
                            new
                            {
                                Response = isHasActiveSubscription
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
        [HttpPost("NewUserSubscription", Name = "NewUserSubscription")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewUserSubscriptionAsync([FromBody] md_NewUserSubscription subscription)
        {
            if (!cls_UsersSubscriptions.ValidateObj_NewMode(subscription))
                return BadRequest(new ApiResponse(false, "Invalid subscription data", new { }));

            try
            {
                int insertedId = await cls_UsersSubscriptions.NewAsync(subscription);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "User subscription doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetSubscriptionById",
                        new
                        {
                            subscriptionId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "User subscription inserted successfully.",
                            new
                            {
                                Subscription = await cls_UsersSubscriptions.GetSubscriptionByIdAsync(insertedId)
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
        [HttpPost("NewUserSubscriptionByUser", Name = "NewUserSubscriptionByUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewUserSubscriptionByUserAsync([FromBody] md_NewByUser subscription)
        {
            if (!cls_UsersSubscriptions.ValidateObj_NewMode(subscription))
                return BadRequest(new ApiResponse(false, "Invalid subscription data", new { }));

            try
            {

                int insertedId = await cls_UsersSubscriptions.NewByUserAsync(subscription);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "User subscription doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetSubscriptionById",
                        new
                        {
                            subscriptionId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "User subscription inserted successfully.",
                            new
                            {
                                Subscription = await cls_UsersSubscriptions.GetSubscriptionByIdAsync(insertedId)
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
        [HttpGet("GetUsersSubscriptionsAnalytics", Name = "GetUsersSubscriptionsAnalytics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersSubscriptionsAnalyticsAsync()
        {
            try
            {
                var (TotalSubscriptions, TotalSubscriptionsThisMonth) = await cls_UsersSubscriptions.GetUsersSubscriptionsAnalyticsAsync();

                if (TotalSubscriptions >= 0)
                {
                    return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                TotalSubscriptions,
                                TotalSubscriptionsThisMonth
                            }
                        )
                    );
                }
                else
                {
                    return BadRequest(new ApiResponse(false, "Error retrieving subscriptions data.", new { }));
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
