using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class ProjectTechnology
    {
        public Guid ProjectId { get; private set; }
        public Guid TechnologieId { get; private set; }
        public Project Project { get; private set; }
        public Technology Technologie { get; private set; }

        private ProjectTechnology()
        {
            
        }
        public static ProjectTechnology CreateProjectTechnology(Project project, Technology technology)
        {
            ProjectTechnology projectTechnology = new ProjectTechnology();
            projectTechnology.Project = project;
            projectTechnology.Technologie = technology;
            return projectTechnology;
        }
    }
}
