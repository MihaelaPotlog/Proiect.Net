using System;
using System.Collections.Generic;
using System.Threading;
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

        [HttpGet("data=users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetUsers(cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid Id, CancellationToken cancellationToken)
        {
            UserDto user = await _userService.GetUser(Id, cancellationToken);
            return Ok(user);
        }

        [HttpGet("data=technologies")]
        public async Task<ActionResult<IEnumerable<Technology>>> GetAllTechnologies(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetTechnologies(cancellationToken));
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _userService.LoginUser(dto, cancellationToken);
            try
            {
                if (user != null)
                {
                    return Ok(user.Id);
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
        public async Task<ActionResult<string>> CreateUser(CreateUserDto dto, CancellationToken cancellationToken)
        {
            var raspuns = await _userService.RegisterUser(dto, cancellationToken);
            if (raspuns.Equals("success"))
                return raspuns;
            else
                return BadRequest(raspuns);
        }

        [HttpPut]
        public async Task<ActionResult> ModifyUser(ModifyUserDto dto, CancellationToken cancellationToken)
        {
            string result = await _userService.ModifyUser(dto, cancellationToken);
            if (result != "success")
                return BadRequest(result);
            else
                return Ok(result);

        }
    }


}
