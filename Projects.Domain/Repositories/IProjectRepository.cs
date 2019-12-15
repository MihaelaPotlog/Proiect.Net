using Projects.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Repositories
{
    public interface IProjectRepository
    {
        // List<Project> GetAll();
        bool Delete(Guid projectId);
        Project Get(Guid projectId);
        Project Update(Project project);
        Project Add(Guid ownerId, string name, string description, string state,string[] tehnologii);

        public bool VerifyIf_Project_Exists(Guid projectId);

        public List<Project> Get_Projects_By_State(string projectState);

        public List<Project> Get_Projects_By_OwnerId(Guid ownerId);

        public List<Project> Get_Projects_By_Description(string projectDescription);

    }
}
