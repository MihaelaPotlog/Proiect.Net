using Projects.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Projects.Domain.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsContext ProjectContext;
        public ProjectRepository(ProjectsContext projectsContext){
            ProjectContext = projectsContext;
            }
        public List<Project> GetAll() {
            //var db = new ProjectsContext();
            var projects = (from p in ProjectContext.Projects select p).ToList();
            return projects;
        }
        public bool Delete(Guid projectId) {

            if (VerifyIf_Project_Exists(projectId) == false)
                return false;

            var deletedProject = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            ProjectContext.Remove(deletedProject);
            ProjectContext.SaveChanges();
            return true;
        }
        public Project Get(Guid projectId) {
            var proj = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            return proj;
        }
        public Project Add(Guid ownerId, string name, string description, string state, string[] tehnologii) {
            var newProject = Project.CreateProject(ownerId,name, description, state);
            ProjectContext.Projects.Add(newProject);
            ProjectContext.SaveChanges();
            return newProject;
        }

        public Project Update(Project project) {

            var updatedProject = (from p in ProjectContext.Projects where p.Id == project.Id select p).FirstOrDefault();
            updatedProject.Name = project.Name;
            updatedProject.OwnerId = project.OwnerId;
            updatedProject.ProjectTechnologies = project.ProjectTechnologies;
            updatedProject.State = project.State;
            updatedProject.Description = project.Description;

            ProjectContext.SaveChanges();

            return updatedProject;

        }

        public bool VerifyIf_Project_Exists(Guid projectId)
        {
            var proj = (from p in ProjectContext.Projects where p.Id == projectId select p).FirstOrDefault();

            if (proj == null)
                return false;
            return true;
        }

        public List<Project> Get_Projects_By_State(string projectState)
        {
            var projects = (from p in ProjectContext.Projects where p.State == projectState select p).ToList();

            return projects;

        }

        public List<Project> Get_Projects_By_OwnerId(Guid ownerId)
        {
            var projects = (from p in ProjectContext.Projects where p.OwnerId == ownerId select p).ToList();

            return projects;

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
