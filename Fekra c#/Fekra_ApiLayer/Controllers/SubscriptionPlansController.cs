using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Subscription_Plans;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlansController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetActivePlansByBranch/{branchId}", Name = "GetActivePlansByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetActivePlansByBranchAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_ActiveSubscriptionPlans>? plans = await cls_SubscriptionPlans.GetActivePlansByBranchAsync(branchId);

                if (plans == null)
                    return NotFound(new ApiResponse(true, "Not subscription plans found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                SubscriptionPlans = plans,
                                count = plans.Count
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
        [HttpGet("GetPlansByBranch/{branchId}", Name = "GetPlansByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPlansByBranchAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_SubscriptionPlans>? plans = await cls_SubscriptionPlans.GetByBranchAsync(branchId);

                if (plans == null)
                    return NotFound(new ApiResponse(true, "Not subscription plans found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                SubscriptionPlans = plans,
                                count = plans.Count
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
        [HttpGet("GetPlanById/{planId}", Name = "GetPlanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPlanByIdAsync(int planId)
        {
            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            try
            {
                md_SubscriptionPlans? plan = await cls_SubscriptionPlans.GetByIdAsync(planId);

                if (plan == null)
                    return NotFound(new ApiResponse(true, "Subscription plan not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Plan = plan
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
        [HttpDelete("DeleteSubscriptionPlan/{planId}/{byAdmin}", Name = "DeleteSubscriptionPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteSubscriptionPlanAsync([FromRoute] int planId, [FromRoute] int byAdmin)
        {

            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_SubscriptionPlans.DeleteAsync(planId, byAdmin);
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
                            "Please verify the plan ID and byAdmin.",
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
        [HttpGet("IsSubscriptionPlanHasRelations/{planId}", Name = "IsSubscriptionPlanHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsSubscriptionPlanHasRelations([FromRoute] int planId)
        {
            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            try
            {
                bool isHasRelations = await cls_SubscriptionPlans.IsHasRelationsAsync(planId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "The subscription plan has relations." : "The subscription plan does not has relations.",
                            new
                            {
                                HasRelations = isHasRelations
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
        [HttpPost("NewSubscriptionPlan", Name = "NewSubscriptionPlan")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewSubscriptionPlanAsync([FromBody] md_NewSubscriptionPlan plan)
        {
            if (!cls_SubscriptionPlans.ValidateObj_NewMode(plan))
                return BadRequest(new ApiResponse(false, "Invalid subscription plan data", new { }));

            try
            {
                int insertedId = await cls_SubscriptionPlans.NewAsync(plan);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Subscription plan doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetPlanById",
                        new
                        {
                            planId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Subscription plan inserted successfully.",
                            new
                            {
                                SubscriptionPlan = await cls_SubscriptionPlans.GetByIdAsync(insertedId)
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
        [HttpPatch("SetSubscriptionPlanAsActive/{planId}/{byAdmin}", Name = "SetSubscriptionPlanAsActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetSubscriptionPlanAsActiveAsync([FromRoute] int planId, [FromRoute] int byAdmin)
        {

            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_SubscriptionPlans.SetAsActiveAsync(planId, byAdmin);
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
                            "Please verify the plan ID and byAdmin.",
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
        [HttpPatch("SetSubscriptionPlanAsInActive/{planId}/{byAdmin}", Name = "SetSubscriptionPlanAsInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetSubscriptionPlanAsInActiveAsync([FromRoute] int planId, [FromRoute] int byAdmin)
        {

            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_SubscriptionPlans.SetAsInActiveAsync(planId, byAdmin);
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
                            "Please verify the plan ID and byAdmin.",
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
        [HttpPatch("SetSubscriptionPlanDescription/{planId}/{description}/{byAdmin}", Name = "SetSubscriptionPlanDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetSubscriptionPlanDescriptionAsync([FromRoute] int planId, [FromRoute] string description, [FromRoute] int byAdmin)
        {

            if (planId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid plan ID.", new { }));

            if (string.IsNullOrEmpty(description) || description.Length > 250)
                return BadRequest(new ApiResponse(false, "Invalid description.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_SubscriptionPlans.SetDescriptionAsync(planId, description, byAdmin);
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
                            "Please verify the plan ID and byAdmin.",
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
        [HttpPut("UpdateSubscriptionPlan", Name = "UpdateSubscriptionPlan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateSubscriptionPlanAsync([FromBody] md_UpdateSubscriptionPlan plan)
        {
            if (!cls_SubscriptionPlans.ValidateObj_UpdateMode(plan))
                return BadRequest(new ApiResponse(false, "Invalid subscription plan data", new { }));

            try
            {
                bool response = await cls_SubscriptionPlans.UpdateAsync(plan);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Subscription plan doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Subscription plan updated successfully.", new { }));
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
