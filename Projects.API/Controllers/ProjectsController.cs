﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Domain.Models;
using Projects.Service;
using Projects.Service.DTOs;

namespace Projects.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
            
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto dto, CancellationToken cancellationToken)
        {
            var createdProject =  await _projectService.CreateProject(dto, cancellationToken);
            return createdProject;

        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects(CancellationToken cancellationToken)
        {
            return await  _projectService.GetProjects(cancellationToken);
        }

        [HttpPost("invitations")]
        public async Task<ActionResult<string>> CreateInvitation(CreateInvitationDto dto, CancellationToken cancellationToken)
        {
            string result = await _projectService.CreateInvitation(dto, cancellationToken);
            if (result != "success")
                return BadRequest(result);
           
            return Ok();
        }

        [HttpGet("invitations")]
        public async Task<ActionResult<List<Invitation>>> GetUserInvitations(GetUserInvitationDto dto,CancellationToken cancellationToken)
        {
            var result = await _projectService.GetUserInvitations(dto, cancellationToken);
            if (result == null)
                return BadRequest("nothing");
            else { 
                return Ok(result); 
            }
        }

        [HttpGet("requests")]
        public async Task<ActionResult<List<Invitation>>> GetOwnerRequests(GetOwnerRequestDto dto, CancellationToken cancellationToken)
        {
            var result = await _projectService.GetOwnerRequests(dto, cancellationToken);
            if (result == null)
                return BadRequest("nothing");
            else
            {
                return Ok(result);
            }
        }
    }
}
