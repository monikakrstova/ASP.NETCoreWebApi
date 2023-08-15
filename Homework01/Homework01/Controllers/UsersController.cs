using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet] //http:localhost:[port]/api/Users
        public ActionResult<List<string>> Get()
        {
            try
            {
                var usersDb = StaticDb.Users;
                return Ok(usersDb);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }  
        }
        [HttpGet("{index}")]
        public ActionResult<List<string>> GetSingle(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("Index can not be a negative value.");
                }

                return Ok(StaticDb.Users[index]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Argument out of range, there is no index with that number");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
    }
}
