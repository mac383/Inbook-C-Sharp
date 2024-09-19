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
                return Ok
                    (
                        new ApiResponse
                        (
                            response,
                            response ? "Success." : "Please verify the error ID and admin ID.",
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
                return Ok
                    (
                        new ApiResponse
                        (
                            response,
                            response ? "Success." : "Please verify the error Id and admin ID.",
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
        [HttpGet("GetPagesCount_All", Name = "GetPagesCount_All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPagesCount_All_Async()
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
        [HttpGet("GetPagesCount_Handled", Name = "GetPagesCount_Handled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPagesCount_Handled_Async()
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
        [HttpGet("GetPagesCount_NotHandled", Name = "GetPagesCount_NotHandled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPagesCount_NotHandled_Async()
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
        [HttpGet("GetById/{errorId}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetByIdAsync([FromRoute] int errorId)
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
        [HttpGet("GetByKey/{key}", Name = "GetByKey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetByKeyAsync([FromRoute] string key)
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
