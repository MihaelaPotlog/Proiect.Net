using Projects.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Projects.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll(CancellationToken cancellationToken);
        bool Delete(Guid projectId);
        Task<Project> Get(Guid projectId, CancellationToken cancellationToken);
        Task<Project> Update(Project project, CancellationToken cancellationToken);
        Task<Project> Add(Guid ownerId, string name, string description, string state, string[] tehnologii, CancellationToken cancellationToken);
        Task Add(Project project, CancellationToken cancellationToken);
        public bool VerifyIf_Project_Exists(Guid projectId);
        Task AddProjectTechnology(Project project, Technology technology, CancellationToken cancellationToken);
        Task AddProjectUser(ProjectUser projectUserLink, CancellationToken cancellationToken);
        Task<Technology> GetTechnologyByName(string name);
        Task<List<Project>> Get_Projects_By_State(string projectState, CancellationToken cancellationToken);

        Task<List<Project>> Get_Projects_By_OwnerId(Guid ownerId, CancellationToken cancellationToken);
        

        public List<Project> Get_Projects_By_Description(string projectDescription);
        Task AddInvitation(Invitation invitation, CancellationToken cancellationToken);
        public Task<ProjectUser> GetProjectUser(Guid projectId, Guid userId);

        public Task<Invitation> GetInvitation(Guid projectId, Guid senderId, Guid receiverId);

        public Task<List<Invitation>> GetaAllInvitationsAsOwner(Guid id,CancellationToken cencellationToken);

        public Task<List<Invitation>> GetaAllInvitationsAsUser(Guid id, CancellationToken cencellationToken);

        public Task<List<string>> GetaAllProjectsNameAsUser(Guid id, CancellationToken cencellationToken);
        public Task<List<string>> GetaAllProjectsNameAsOwner(Guid id, CancellationToken cencellationToken);

    }
}
