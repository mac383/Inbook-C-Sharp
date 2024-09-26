using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.System_Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAdminsCount", Name = "GetAdminsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdminsCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetCountAsync();

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
        [HttpGet("GetDeletionAdminsCount", Name = "GetDeletionAdminsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionAdminsCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetDeletionsCountAsync();

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
        [HttpGet("GetInActiveAdminsCount", Name = "GetInActiveAdminsCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActiveAdminsCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetInActivesCountAsync();

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
        [HttpGet("GetAllAdminsPagesCount", Name = "GetAllAdminsPagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllAdminsPagesCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetAllPagesCountAsync();

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
        [HttpGet("GetDeletionAdminsPagesCount", Name = "GetDeletionAdminsPagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionAdminsPagesCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetDeletionsPagesCountAsync();

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
        [HttpGet("GetInActivesAdminsPagesCount", Name = "GetInActivesAdminsPagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActivesAdminsPagesCountAsync()
        {
            try
            {
                int count = await cls_Admins.GetInActivesPagesCountAsync();

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
        [HttpGet("GetAllAdmins/{pageNumber}", Name = "GetAllAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllAdminsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Admins>? admins = await cls_Admins.GetAllAsync(pageNumber);

                if (admins == null)
                    return NotFound(new ApiResponse(true, "Not admins found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admins = admins,
                                count = admins.Count
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
        [HttpGet("GetAdminsByFullName/{fullName}", Name = "GetAdminsByFullName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdminsByFullNameAsync(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || fullName.Length > 25)
                return BadRequest(new ApiResponse(false, "Invalid fullname.", new { }));

            try
            {
                List<md_Admins>? admins = await cls_Admins.GetByFullNameAsync(fullName);

                if (admins == null)
                    return NotFound(new ApiResponse(true, "Not admins found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admins = admins,
                                count = admins.Count
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
        [HttpGet("GetDeletionAdmins/{pageNumber}", Name = "GetDeletionAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionAdminsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Admins>? admins = await cls_Admins.GetDeletionsAsync(pageNumber);

                if (admins == null)
                    return NotFound(new ApiResponse(true, "Not admins found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admins = admins,
                                count = admins.Count
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
        [HttpGet("GetInActivesAdmins/{pageNumber}", Name = "GetInActivesAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetInActivesAdminsAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Admins>? admins = await cls_Admins.GetInActivesAsync(pageNumber);

                if (admins == null)
                    return NotFound(new ApiResponse(true, "Not admins found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admins = admins,
                                count = admins.Count
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
        [HttpGet("GetAdminByAuth/{userNameOrEmail}/{password}", Name = "GetAdminByAuth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdminByAuthAsync(string userNameOrEmail, string password)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || userNameOrEmail.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid username or email.", new { }));

            if (string.IsNullOrEmpty(password) || password.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid password.", new { }));

            try
            {
                password = Encryption.HashEncrypt(password);

                md_AdminAuth? admin = await cls_Admins.GetByAuthAsync(userNameOrEmail, password);

                if (admin == null)
                    return NotFound(new ApiResponse(true, "Admin not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admin = admin
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
        [HttpGet("GetAdminById/{adminId}", Name = "GetAdminById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdminByIdAsync(int adminId)
        {
            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                md_Admin? admin = await cls_Admins.GetByIdAsync(adminId);

                if (admin == null)
                    return NotFound(new ApiResponse(true, "Admin not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admin = admin
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
        [HttpGet("GetAdminByUserNameOrEmail/{userNameOrEmail}", Name = "GetAdminByUserNameOrEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAdminByUserNameOrEmailAsync(string userNameOrEmail)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || userNameOrEmail.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid username or email.", new { }));

            try
            {
                md_Admins? admin = await cls_Admins.GetByUserNameOrEmailAsync(userNameOrEmail);

                if (admin == null)
                    return NotFound(new ApiResponse(true, "Admin not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Admin = admin
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
        [HttpPatch("ClearPermissions/{adminId}/{byAdmin}", Name = "ClearPermissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> ClearPermissionsAsync([FromRoute] int adminId, [FromRoute] int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.ClearPermissionsAsync(adminId, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpDelete("DeleteAdmin/{adminId}/{byAdmin}", Name = "DeleteAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteAdminAsync([FromRoute] int adminId, [FromRoute] int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.DeleteAsync(adminId, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpPatch("DeleteAdminImage/{adminId}", Name = "DeleteAdminImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteAdminImageAsync([FromRoute] int adminId)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            try
            {
                bool response = await cls_Admins.DeleteImageAsync(adminId);
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
                            "Please verify the admin ID.",
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
        [HttpPost("NewAdmin", Name = "NewAdmin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewAdminAsync([FromBody] md_NewAdmin admin)
        {
            if (!cls_Admins.ValidateObj_NewMode(admin))
                return BadRequest(new ApiResponse(false, "Invalid admin data", new { }));

            try
            {
                int insertedId = await cls_Admins.NewAsync(admin);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Admin doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetAdminById",
                        new
                        {
                            adminId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Admin inserted successfully.",
                            new
                            {
                                Admin = await cls_Admins.GetByIdAsync(insertedId)
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
        [HttpPatch("SetAsActive/{adminId}/{byAdmin}", Name = "SetAsActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAsActiveAsync([FromRoute] int adminId, [FromRoute] int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.SetAsActiveAsync(adminId, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpPatch("SetAsInActive/{adminId}/{byAdmin}", Name = "SetAsInActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAsInActiveAsync([FromRoute] int adminId, [FromRoute] int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.SetAsInActiveAsync(adminId, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpPatch("SetAdminDescription/{adminId}/{description}/{byAdmin}", Name = "SetAdminDescription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminDescriptionAsync([FromRoute] int adminId, [FromRoute] string description, [FromRoute] int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (string.IsNullOrEmpty(description) || description.Length > 250)
                return BadRequest(new ApiResponse(false, "Invalid description.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.SetDescriptionAsync(adminId, description, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpPatch("SetAdminEmail/{adminId}/{email}", Name = "SetAdminEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminEmailAsync([FromRoute] int adminId, [FromRoute] string email)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (!Validation.IsEmailValid(email))
                return BadRequest(new ApiResponse(false, "Invalid email.", new { }));

            try
            {
                bool response = await cls_Admins.SetEmailAsync(adminId, email);
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
                            "Please verify the admin ID and email.",
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
        [HttpPatch("SetAdminFullName/{adminId}/{fullName}", Name = "SetAdminFullName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminFullNameAsync([FromRoute] int adminId, [FromRoute] string fullName)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (!Validation.CheckLength(1, 25, fullName))
                return BadRequest(new ApiResponse(false, "Invalid fullname.", new { }));

            try
            {
                bool response = await cls_Admins.SetFullNameAsync(adminId, fullName);
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
                            "Please verify the admin ID and fullname.",
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
        [HttpPatch("SetAdminImage/{adminId}/{imageURL}/{imageName}", Name = "SetAdminImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminImageAsync([FromRoute] int adminId, [FromRoute] string imageURL, [FromRoute] string imageName)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (string.IsNullOrEmpty(imageURL))
                return BadRequest(new ApiResponse(false, "Invalid image URL.", new { }));

            if (!Validation.CheckLength(1, 150, imageName))
                return BadRequest(new ApiResponse(false, "Invalid image name.", new { }));

            try
            {
                bool response = await cls_Admins.SetImageAsync(adminId, imageURL, imageName);
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
                            "Please verify the admin ID and image name.",
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
        [HttpPatch("SetAdminPassword/{adminId}/{password}", Name = "SetAdminPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminPasswordAsync([FromRoute] int adminId, [FromRoute] string password)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (!Validation.IsPasswordValid(password))
                return BadRequest(new ApiResponse(false, "Invalid password.", new { }));

            try
            {
                bool response = await cls_Admins.SetPasswordAsync(adminId, password);
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
                            "Please verify the admin ID.",
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
        [HttpPatch("SetPermissions/{adminId}/{permissions}/{byAdmin}", Name = "SetPermissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetPermissionsAsync([FromRoute] int adminId, [FromRoute] long permissions, int byAdmin)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Admins.SetPermissionsAsync(adminId, permissions, byAdmin);
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
                            "Please verify the admin ID and byAdmin.",
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
        [HttpPatch("SetAdminUserName/{adminId}/{userName}", Name = "SetAdminUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetAdminUserNameAsync([FromRoute] int adminId, [FromRoute] string userName)
        {

            if (adminId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid admin ID.", new { }));

            if (!Validation.IsUsernameValid(userName))
                return BadRequest(new ApiResponse(false, "Invalid username.", new { }));

            try
            {
                bool response = await cls_Admins.SetUserNameAsync(adminId, userName);
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
                            "Please verify the admin ID and username.",
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
    }
}
