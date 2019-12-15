using Projects.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Projects.Domain.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsContext ProjectContext;
        public ProjectRepository(ProjectsContext projectsContext){
            ProjectContext = projectsContext;
            }
        public async Task<List<Project>> GetAll(CancellationToken cancellationToken) {
            //var db = new ProjectsContext();
            var projects = (from p in ProjectContext.Projects select p).ToListAsync(cancellationToken);
            return await projects;
        }
        public bool Delete(Guid projectId) {

            if (VerifyIf_Project_Exists(projectId) == false)
                return false;

            var deletedProject = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            ProjectContext.Remove(deletedProject);
            ProjectContext.SaveChanges();
            return true;
        }
        public async Task<Project> Get(Guid projectId,CancellationToken cancellationToken) {
            var proj = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefaultAsync(cancellationToken);

            return await proj;
        }
        public async Task<Project> Add(Guid ownerId, string name, string description, string state, string[] tehnologii,CancellationToken cancellationToken) {
            var newProject = Project.CreateProject(ownerId,name, description, state);
            ProjectContext.Projects.Add(newProject);
            await ProjectContext.SaveChangesAsync(cancellationToken);
            return  newProject;
        }

        public async Task<Project> Update(Project project,CancellationToken cancellationToken) {

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

        public async Task<List<Project>> Get_Projects_By_State(string projectState,CancellationToken cancellationToken)
        {
            var projects = (from p in ProjectContext.Projects where p.State == projectState select p).ToListAsync(cancellationToken);

            return await projects;

        }

        public async Task<List<Project>> Get_Projects_By_OwnerId(Guid ownerId,CancellationToken cancellationToken)
        {
            var projects = (from p in ProjectContext.Projects where p.OwnerId == ownerId select p).ToListAsync(cancellationToken);

            return await projects;

        }

        public List<Project> Get_Projects_By_Description(string projectDescription)
        {
            var projects = (from p in ProjectContext.Projects where p.Description == projectDescription select p).ToList();

            return projects;

        }

        public List<Project> Get_Projects_By_Name(string projectName)
        {
            var projects = (from p in ProjectContext.Projects where p.Name == projectName select p).ToList();

            return projects;

        }

    }

}
