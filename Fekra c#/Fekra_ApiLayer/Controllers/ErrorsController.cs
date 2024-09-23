using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {

        // completed testing.
        [HttpPatch("SetAsHandled/{errorId}/{byAdmin}", Name = "SetAsHandled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAsHandledAsync([FromRoute] int errorId, [FromRoute] int byAdmin)
        {

            if (errorId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid errorId value.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin value.", new { }));

            try
            {
                bool response = await cls_Errors.SetAsHandledAsync(errorId, byAdmin);
                if (response)
                    return Ok
                        (
                            new ApiResponse
                            (
                                response,
                                "Success.",
                                new { }
                            )
                        );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            response,
                            "Please verify the error ID and admin ID.",
                            new { }
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
        [HttpPatch("SetDescription/{errorId}/{description}/{byAdmin}", Name = "SetDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetDescriptionAsync([FromRoute] int errorId, [FromRoute] string description, [FromRoute] int byAdmin)
        {

            if (errorId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid errorId value.", new { }));

            if (string.IsNullOrEmpty(description))
                return BadRequest(new ApiResponse(false, "Invalid description.", new { }));

            if (description.Length > 250)
                return BadRequest(new ApiResponse(false, "Invalid description, The description cannot exceed 250 characters.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin value.", new { }));

            try
            {

                bool response = await cls_Errors.SetDescriptionAsync(errorId, description, byAdmin);
                if (response)
                    return Ok
                    (
                        new ApiResponse
                        (
                            response,
                            "Success.",
                            new { }
                        )
                    );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            response,
                            "Please verify the error Id and admin ID.",
                            new { }
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
        [HttpGet("GetErrorsPagesCount_All", Name = "GetErrorsPagesCount_All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetErrorsPagesCount_All_Async()
        {
            try
            {
                int _count = await cls_Errors.GetPagesCount_All_Async();
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetErrorsPagesCount_Handled", Name = "GetErrorsPagesCount_Handled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetErrorsPagesCount_Handled_Async()
        {
            try
            {
                int _count = await cls_Errors.GetPagesCount_Handled_Async();
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetErrorsPagesCount_NotHandled", Name = "GetErrorsPagesCount_NotHandled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetErrorsPagesCount_NotHandled_Async()
        {
            try
            {
                int _count = await cls_Errors.GetPagesCount_NotHandled_Async();
                return Ok
                    (
                        new ApiResponse
                        (
                            _count >= 0,
                            _count >= 0 ? "Success." : "Failed.",
                            new
                            {
                                count = _count
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
        [HttpGet("GetAllErrors/{pageNumber}", Name = "GetAllErrors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllErrorsAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Errors>? errors = await cls_Errors.GetAll(pageNumber);

                if (errors == null)
                    return NotFound(new ApiResponse(true, "Not errors found.", new { }));
                    
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new 
                            {
                                Errors = errors,
                                count = errors.Count
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
        [HttpGet("GetHandledErrors/{pageNumber}", Name = "GetHandledErrors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetHandledErrorsAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Errors>? errors = await cls_Errors.GetHandledErrorsAsync(pageNumber);

                if (errors == null)
                    return NotFound(new ApiResponse(true, "Not errors found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Errors = errors,
                                count = errors.Count
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
        [HttpGet("GetNotHandledErrors/{pageNumber}", Name = "GetNotHandledErrors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetNotHandledErrorsAsync([FromRoute] int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Page number must be positive.", new { }));

            try
            {
                List<md_Errors>? errors = await cls_Errors.GetNotHandledErrorsAsync(pageNumber);

                if (errors == null)
                    return NotFound(new ApiResponse(true, "Not errors found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Errors = errors,
                                count = errors.Count
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
        [HttpGet("GetErrorById/{errorId}", Name = "GetErrorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetErrorByIdAsync([FromRoute] int errorId)
        {
            if (errorId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid error ID.", new { }));

            try
            {
                md_Error? error = await cls_Errors.GetById(errorId);

                if (error == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Error = error
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
        [HttpGet("GetErrorByKey/{key}", Name = "GetErrorByKey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetErrorByKeyAsync([FromRoute] string key)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest(new ApiResponse(false, "Invalid error Key.", new { }));

            if (key.Length > 25)
                return BadRequest(new ApiResponse(false, "Invalid error key, The key cannot exceed 25 characters.", new { }));

            try
            {
                md_Error? error = await cls_Errors.GetByKey(key);

                if (error == null)
                    return NotFound(new ApiResponse(true, "Resource not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Error = error
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
