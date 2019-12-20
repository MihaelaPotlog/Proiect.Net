using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class ProjectUser
    {
        public Guid ProjectId { get; private set; }
        public Guid UserId { get; private set; }

        public Project Project { get; private set; }

        private ProjectUser()
        {
            
        }

        public static ProjectUser CreateProjectUser(Guid projectId, Guid userId, Project project)
        {
            return new ProjectUser()
            {
                ProjectId = projectId,
                UserId = userId,
                Project = project,
            };
        }
        
    }
}
