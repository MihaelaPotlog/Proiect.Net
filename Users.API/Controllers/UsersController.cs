﻿using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetUsers(cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetUserById(string Id, CancellationToken cancellationToken)
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
        public async Task<ActionResult<IResponseDto>> Login(LoginUserDto dto, CancellationToken cancellationToken)
        {
            var response = await _userService.Login(dto, cancellationToken);
            if (response.Succeded)
                return Ok(response);
            else 
                return BadRequest(response);

        }


        [HttpPost]
        public async Task<ActionResult<IResponseDto>> CreateUser(CreateUserDto dto, CancellationToken cancellationToken)
        {
            var response = await _userService.Register(dto, cancellationToken);
            if (response.Succeded)
                return Ok(response);
            else
                return BadRequest(response);
        }

        

        [HttpPost("suggestions")]
        public async Task<List<UserDto>> GetUserSuggestions(SuggestionsDto neededTechnologies, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("AIIIIICI: ", neededTechnologies.NeededTechnologies);
            List<UserDto> suggestedUsers = await _userService.GetUserSuggestions(neededTechnologies.NeededTechnologies, cancellationToken);
            return suggestedUsers;
        }
    }


}
