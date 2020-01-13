using Projects.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Projects.Domain.Common;

namespace Projects.Domain.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsContext ProjectContext;

        public ProjectRepository(ProjectsContext projectsContext)
        {
            ProjectContext = projectsContext;
        }

        // public async Task<List<Project>> GetAll(CancellationToken cancellationToken) {
        //     //var db = new ProjectsContext();
        //     var projects = (from p in ProjectContext.Projects select p).ToListAsync(cancellationToken);
        //     return await projects;
        // }
        public Task<List<Project>> GetAll(CancellationToken cancellationToken)
        {
            return ProjectContext.Projects
                .Include(project => project.ProjectUsers)
                .Include(project => project.ProjectTechnologies)
                .ThenInclude(projectTechnology => projectTechnology.Technologie)
                .ToListAsync(cancellationToken);
        }

        public bool Delete(Guid projectId)
        {

            if (VerifyIf_Project_Exists(projectId) == false)
                return false;

            var deletedProject = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            ProjectContext.Remove(deletedProject);
            ProjectContext.SaveChanges();
            return true;
        }

        public async Task<Project> Get(Guid projectId, CancellationToken cancellationToken)
        {
            var proj =
                (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefaultAsync(
                    cancellationToken);

            return await proj;
        }

        public async Task<Project> Add(Guid ownerId, string name, string description, string state, string[] tehnologii,
            CancellationToken cancellationToken)
        {
            var newProject = Project.CreateProject(ownerId, name, description, state);
            ProjectContext.Projects.Add(newProject);
            await ProjectContext.SaveChangesAsync(cancellationToken);
            return newProject;
        }

        public async Task Add(Project project, CancellationToken cancellationToken)
        {
            ProjectContext.Projects.Add(project);
            await ProjectContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Project> Update(Project project, CancellationToken cancellationToken)
        {

            var updatedProject = (from p in ProjectContext.Projects where p.Id == project.Id select p).FirstOrDefault();
            updatedProject.Name = project.Name;
            updatedProject.OwnerId = project.OwnerId;
            updatedProject.ProjectTechnologies = project.ProjectTechnologies;
            updatedProject.State = project.State;
            updatedProject.Description = project.Description;

            await ProjectContext.SaveChangesAsync(cancellationToken);

            return updatedProject;

        }

        public bool VerifyIf_Project_Exists(Guid projectId)
        {
            var proj = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            if (proj == null)
                return false;
            return true;
        }

        public async Task<List<Project>> Get_Projects_By_State(string projectState, CancellationToken cancellationToken)
        {
            var projects =
                (from p in ProjectContext.Projects where p.State == projectState select p).ToListAsync(
                    cancellationToken);

            return await projects;

        }

        public async Task<List<Project>> Get_Projects_By_OwnerId(Guid ownerId, CancellationToken cancellationToken)
        {
            var projects =
                (from p in ProjectContext.Projects where p.OwnerId == ownerId select p).ToListAsync(cancellationToken);

            return await projects;

        }

        public List<Project> Get_Projects_By_Description(string projectDescription)
        {
            var projects =
                (from p in ProjectContext.Projects where p.Description == projectDescription select p).ToList();

            return projects;

        }

        public List<Project> Get_Projects_By_Name(string projectName)
        {
            var projects = (from p in ProjectContext.Projects where p.Name == projectName select p).ToList();

            return projects;

        }

        public async Task<Technology> GetTechnologyByName(string name)
        {
            Technology wantedTechnology =
                await ProjectContext.Technologies.FirstOrDefaultAsync(technology => technology.Name == name);
            return wantedTechnology;
        }

        public async Task AddProjectTechnology(Project project, Technology technology,
            CancellationToken cancellationToken)
        {
            ProjectTechnology projectTechnologyLink = ProjectTechnology.CreateProjectTechnology(project, technology);
            ProjectContext.ProjectTechnologies.Add(projectTechnologyLink);
            await ProjectContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddProjectUser(ProjectUser projectUserLink, CancellationToken cancellationToken)
        {
            ProjectContext.ProjectUsers.Add(projectUserLink);
            await ProjectContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProjectUser> GetProjectUser(Guid projectId, Guid userId)
        {
            return await ProjectContext.ProjectUsers.FindAsync(projectId, userId);
        }

        public async Task AddInvitation(Invitation invitation, CancellationToken cancellationToken)
        {
            ProjectContext.Invitations.Add(invitation);
            await ProjectContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Invitation> GetInvitation(Guid projectId, Guid collaboratorId, Guid ownerId)
        {
            return await ProjectContext.Invitations.FindAsync(projectId, collaboratorId, ownerId);

        }

        public async Task<List<Invitation>> GetaAllInvitationsAsOwner(Guid id, CancellationToken cancellationToken)
        {

            var invitations = (from i in ProjectContext.Invitations where i.OwnerId == id && i.InvitationType == InvitationType.UserToOwner select i)
                .Include(invitation => invitation.Project)
                .ToListAsync(cancellationToken);

            return await invitations;
        }

        public async Task<List<Invitation>> GetaAllInvitationsAsUser(Guid id, CancellationToken cancellationToken)
        {
            var invitations =
                (from i in ProjectContext.Invitations where i.CollaboratorId == id && i.InvitationType == InvitationType.OwnerToUser select i)
                .Include(invitation => invitation.Project)
                .ToListAsync(cancellationToken);

            return await invitations;
        }

        public async Task<List<string>> GetaAllProjectsNameAsOwner(Guid id, CancellationToken cancellationToken)
        {
            var projectsAsOwner = (from i in ProjectContext.Projects where i.OwnerId == id select i.Name).ToListAsync(cancellationToken);

            return await projectsAsOwner;
        }

        public async Task<List<string>> GetaAllProjectsNameAsUser(Guid id, CancellationToken cancellationToken)
        {
            var projectsAsUser = (from i in ProjectContext.Projects where i.ProjectUsers.Any(x => x.UserId == id) select i.Name).ToListAsync(cancellationToken);

            return await projectsAsUser;
        }
    


        public async Task RemoveInvitation(Invitation invitation)
        {
            ProjectContext.Invitations.Remove(invitation);
            await ProjectContext.SaveChangesAsync();
        }

        public async Task<Project> GetProjectInfo(Guid id, CancellationToken cancellationToken)
        {
            Project selectedProject = await ProjectContext.Projects.Where(project => project.Id == id).FirstOrDefaultAsync(cancellationToken);
            ProjectContext.Entry(selectedProject).Collection(project=> project.ProjectTechnologies)
                                                .Query()
                                                .Include(projTech=>projTech.Technologie)
                                                .Load();
            ProjectContext.Entry(selectedProject).Collection(project => project.ProjectUsers).Load();
            return selectedProject;
        }

    }
}
