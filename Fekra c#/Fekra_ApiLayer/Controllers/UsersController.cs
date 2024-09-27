using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_BusinessLayer.Utils;
using Fekra_DataAccessLayer.models.Admins;
using Fekra_DataAccessLayer.models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetAllUsers/{pageNumber}", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllUsersAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Users>? users = await cls_Users.GetAllAsync(pageNumber);

                if (users == null)
                    return NotFound(new ApiResponse(true, "Not users found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Users = users,
                                count = users.Count
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
        [HttpGet("GetUserByAuth/{userNameOrEmail}/{password}", Name = "GetUserByAuth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUserByAuthAsync(string userNameOrEmail, string password)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || userNameOrEmail.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid username or email.", new { }));

            if (string.IsNullOrEmpty(password) || password.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid password.", new { }));

            try
            {
                password = Encryption.HashEncrypt(password);

                md_UserAuth? user = await cls_Users.GetByAuthAsync(userNameOrEmail, password);

                if (user == null)
                    return NotFound(new ApiResponse(true, "User not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                User = user
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
        [HttpGet("GetUsersByFullName/{fullName}", Name = "GetUsersByFullName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersByFullNameAsync(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || fullName.Length > 25)
                return BadRequest(new ApiResponse(false, "Invalid fullname.", new { }));

            try
            {
                List<md_Users>? users = await cls_Users.GetByFullNameAsync(fullName);

                if (users == null)
                    return NotFound(new ApiResponse(true, "Not users found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Users = users,
                                count = users.Count
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
        [HttpGet("GetUserById/{userId}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUserByIdAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                md_User? user = await cls_Users.GetByIdAsync(userId);

                if (user == null)
                    return NotFound(new ApiResponse(true, "User not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                User = user
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
        [HttpGet("GetUserByUserNameOrEmail/{userNameOrEmail}", Name = "GetUserByUserNameOrEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUserByUserNameOrEmailAsync(string userNameOrEmail)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || userNameOrEmail.Length > 150)
                return BadRequest(new ApiResponse(false, "Invalid username or email.", new { }));

            try
            {
                md_Users? user = await cls_Users.GetByUserNameOrEmailAsync(userNameOrEmail);

                if (user == null)
                    return NotFound(new ApiResponse(true, "User not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                User = user
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
        [HttpGet("GetDeletionUsers/{pageNumber}", Name = "GetDeletionUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionUsersAsync(int pageNumber)
        {
            if (pageNumber <= 0)
                return BadRequest(new ApiResponse(false, "Invalid page number.", new { }));

            try
            {
                List<md_Users>? users = await cls_Users.GetDeletionsAsync(pageNumber);

                if (users == null)
                    return NotFound(new ApiResponse(true, "Not users found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Users = users,
                                count = users.Count
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
        [HttpGet("GetUsersCount", Name = "GetUsersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersCountAsync()
        {
            try
            {
                int count = await cls_Users.GetCountAsync();

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
        [HttpGet("GetDeletionUsersCount", Name = "GetDeletionUsersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionUsersCountAsync()
        {
            try
            {
                int count = await cls_Users.GetDeletionsCountAsync();

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
        [HttpGet("GetAllUsersPagesCount", Name = "GetAllUsersPagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllUsersPagesCountAsync()
        {
            try
            {
                int count = await cls_Users.GetPagesCountAllAsync();

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
        [HttpGet("GetDeletionUsersPagesCount", Name = "GetDeletionUsersPagesCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetDeletionUsersPagesCountAsync()
        {
            try
            {
                int count = await cls_Users.GetPagesCountDeletionsAsync();

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
        [HttpGet("GetUsersCountByBranch/{branchId}", Name = "GetUsersCountByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetUsersCountByBranchAsync([FromRoute] int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                int count = await cls_Users.GetCountByBranchAsync(branchId);

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
        [HttpPatch("DeleteUserImage/{userId}", Name = "DeleteUserImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteUserImageAsync([FromRoute] int userId)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            try
            {
                bool response = await cls_Users.DeleteImageAsync(userId);
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
        [HttpPost("NewUser", Name = "NewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewUserAsync([FromBody] md_NewUser user)
        {
            if (!cls_Users.ValidateObj_NewMode(user))
                return BadRequest(new ApiResponse(false, "Invalid user data", new { }));

            try
            {
                int insertedId = await cls_Users.NewAsync(user);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "User doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetUserById",
                        new
                        {
                            userId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "User inserted successfully.",
                            new
                            {
                                User = await cls_Users.GetByIdAsync(insertedId)
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
        [HttpPatch("SetUserEmail/{userId}/{email}", Name = "SetUserEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetUserEmailAsync([FromRoute] int userId, [FromRoute] string email)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (!Validation.IsEmailValid(email))
                return BadRequest(new ApiResponse(false, "Invalid email.", new { }));

            try
            {
                bool response = await cls_Users.SetEmailAsync(userId, email);
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
                            "Please verify the user ID and email.",
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
        [HttpPatch("SetUserFullName/{userId}/{fullName}", Name = "SetUserFullName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetUserFullNameAsync([FromRoute] int userId, [FromRoute] string fullName)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (!Validation.CheckLength(1, 25, fullName))
                return BadRequest(new ApiResponse(false, "Invalid fullname.", new { }));

            try
            {
                bool response = await cls_Users.SetFullNameAsync(userId, fullName);
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
                            "Please verify the user ID and fullname.",
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
        [HttpPatch("SetUserImage/{userId}/{imageURL}/{imageName}", Name = "SetUserImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetUserImageAsync([FromRoute] int userId, [FromRoute] string imageURL, [FromRoute] string imageName)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (string.IsNullOrEmpty(imageURL))
                return BadRequest(new ApiResponse(false, "Invalid image URL.", new { }));

            if (!Validation.CheckLength(1, 150, imageName))
                return BadRequest(new ApiResponse(false, "Invalid image name.", new { }));

            try
            {
                bool response = await cls_Users.SetImageAsync(userId, imageURL, imageName);
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
                            "Please verify the user ID and image name.",
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
        [HttpPatch("SetUserPassword/{userId}/{password}", Name = "SetUserPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetUserPasswordAsync([FromRoute] int userId, [FromRoute] string password)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (!Validation.IsPasswordValid(password))
                return BadRequest(new ApiResponse(false, "Invalid password.", new { }));

            try
            {
                bool response = await cls_Users.SetPasswordAsync(userId, password);
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
        [HttpPatch("SetUserUserName/{userId}/{userName}", Name = "SetUserUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> SetUserUserNameAsync([FromRoute] int userId, [FromRoute] string userName)
        {

            if (userId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid user ID.", new { }));

            if (!Validation.IsUsernameValid(userName))
                return BadRequest(new ApiResponse(false, "Invalid username.", new { }));

            try
            {
                bool response = await cls_Users.SetUserNameAsync(userId, userName);
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
                            "Please verify the user ID and username.",
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
