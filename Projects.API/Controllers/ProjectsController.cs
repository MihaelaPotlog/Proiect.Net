using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projects.Domain.Models;
using Projects.Service;
using Projects.Service.Common;
using Projects.Service.Constants;
using Projects.Service.DTOs;
using Projects.Service.DTOs.RequestsDTOs;

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

        [HttpGet("requests/{id}")]
        public async Task<ActionResult<List<ResponseInvitationDTO>>> GetOwnerRequests(Guid id, CancellationToken cancellationToken)
        {
            var result = await _projectService.GetOwnerRequests(id, cancellationToken);
            if (result == null)
                return BadRequest("nothing");
            else
            {
                return Ok(result);
            }
        }

        //First list as owner,second as User
        [HttpGet("my-projects/{id}")]
        public async Task<ActionResult<List<List<string>>>> GetProjectsNameByClientId(Guid id,CancellationToken cancellationToken)
        {
            

            var result = await _projectService.GetProjectsNameByClientId(id, cancellationToken);
            return Ok(result);
            

        [HttpPost("handleinvitation")]
        public async Task<ActionResult> HandleInvitation(HandleInvitationDto request, CancellationToken cancellationToken)
        {
            string response = await _projectService.HandleInvitation(request, cancellationToken);
            if (response == SuccessMessages.Success)
                return Ok(response);
            else 
                return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id, CancellationToken cancellationToken)
        {
            ProjectDto response = await _projectService.GetProject(id, cancellationToken);
            if (response == null)
                return BadRequest(ErrorMessages.NonexistentProject);

            return Ok(response);

        }
    }
}
