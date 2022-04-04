using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegDetails.Data;
using RegDetails.Model;
using System.Linq;

namespace RegDetails.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        public readonly UserDbContext _dataModel;


        public AdminController(UserDbContext userData)
        {
            _dataModel = userData;

        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userDetails = _dataModel.AdminLogin.AsQueryable();
            return Ok(userDetails);
        }

        [HttpPost("Singup")]
        public IActionResult Singup([FromBody] UserModel obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            else
            {
                _dataModel.AdminLogin.Add(obj);
                _dataModel.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "User Added Successfully"
                });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _dataModel.AdminLogin.Where(q =>
                q.Username == userObj.Username
                && q.Password == userObj.Password).FirstOrDefault();

                if (user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Sucessfully"

                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }

            }

        }
    }
}
