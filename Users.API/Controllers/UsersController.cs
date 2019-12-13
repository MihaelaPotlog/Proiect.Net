using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.Models;
using Users.Service;
using Users.Service.DTOs;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost("login")]
        public ActionResult<User> LoginUser(LoginUserDto dto)
        {
            var user = _userService.LoginUser(dto);
            try
            {
                if (user != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public ActionResult<string> CreateUser(CreateUserDto dto)
        {
            var raspuns = _userService.RegisterUser(dto);
            if (raspuns.Equals("success"))
                return raspuns;
            else
                return BadRequest(raspuns);
        }
        [HttpPut]
        public ActionResult<User> ModifyUser(ModifyUserDto dto)
        {
            // User modifiedUser = _userService.ModifyUser(dto);
            // if (modifiedUser == null)
            //     return BadRequest();
            // else
            //     return Ok(modifiedUser);
            return BadRequest();
        }
    }

    public class UserDto
    {
    }
}
