using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projects.Domain.Models;
using Projects.Service;
using Projects.Service.Common;
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
        public async Task<ActionResult<Project>> CreateProject(CreateProjectDto dto, CancellationToken cancellationToken)
        {
            return await _projectService.CreateProject(dto, cancellationToken);
        }

        [HttpPost("invitations")]
        public async Task<ActionResult<string>> CreateInvitation(CreateInvitationDto dto, CancellationToken cancellationToken)
        {
            string result = await _projectService.CreateInvitation(dto, cancellationToken);
            if (result != "success")
                return BadRequest(result);
           
            return Ok();
        }
    }
}
