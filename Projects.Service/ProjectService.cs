using Projects.Domain.Models;
using Projects.Service.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;
using Projects.Domain.Repositories;

namespace Projects.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> CreateProject(CreateProjectDto request, CancellationToken cancellationToken)
        {
            Project createdProject = Project.CreateProject(request.OwnerId,request.Name, request.Description, request.State);
            await _projectRepository.Add(createdProject, cancellationToken);

            foreach (string technologyName in request.Technologies)
            {
                Technology technology = await _projectRepository.GetTechnologyByName(technologyName);
                await _projectRepository.AddProjectTechnology(createdProject, technology, cancellationToken);
            }

            return createdProject;
        }
    }
}
