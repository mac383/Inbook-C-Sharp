using Fekra_BusinessLayer;
using Fekra_BusinessLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {

        [HttpGet("CheckEmail", Name = "CheckEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> CheckEmail([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest("The input cannot be null or empty.");

            return Ok(Validation.IsEmailValid(email));
        }

        [HttpGet("CheckUserName", Name = "CheckUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> CheckUserName([FromQuery] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest("The input cannot be null or empty.");

            return Ok(Validation.IsUsernameValid(userName));
        }

        [HttpGet("CheckPassword", Name = "CheckPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> CheckPassword([FromQuery] string password)
        {
            if (string.IsNullOrEmpty(password))
                return BadRequest("The input cannot be null or empty.");

            return Ok(Validation.IsPasswordValid(password));
        }

        [HttpGet("CheckLength", Name = "CheckLength")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> CheckLength([FromQuery] int min, [FromQuery] int max, [FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("The input cannot be null or empty.");

            if (min < 1 || max < 1)
                return BadRequest("The input values must be greater than or equal to 1.");

            if (min > max)
                return BadRequest("The minimum value cannot be greater than the maximum value.");

            return Ok(Validation.CheckLength(min, max, text));
        }

        [HttpGet("IsText", Name = "IsText")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> IsText([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("The input cannot be null or empty.");

            return Ok(Validation.IsText(text));
        }

        [HttpGet("IsINT", Name = "IsINT")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> IsINT([FromQuery] int number)
        {
            return Ok(Validation.IsInt(number.ToString()));
        }

        [HttpGet("IsFloat", Name = "IsFloat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> IsFloat([FromQuery] double number)
        {
            return Ok(Validation.IsFloat(number.ToString()));
        }

    }
}
