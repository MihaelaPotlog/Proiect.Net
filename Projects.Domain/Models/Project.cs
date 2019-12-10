using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class Project
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string State { get; private set; }

        public List<ProjectTechnology> ProjectTechnologies { get; private set; }
        public List<ProjectUser> ProjectUsers { get; private set; }

        private Project()
        {
            Id = Guid.NewGuid();
            ProjectTechnologies = new List<ProjectTechnology>();
            ProjectUsers = new List<ProjectUser>();
        }
        public static Project CreateProject(string name, string description, string state)
        {
            return new Project()
            {
                Name = name,
                Description = description,
                State = state
            };
        }
    }
}
