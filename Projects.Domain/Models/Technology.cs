using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class Technology
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }

        private Technology()
        {
            Id = Guid.NewGuid();
            ProjectTechnologies = new List<ProjectTechnology>();
        }
        public static Technology CreateTechnology(string name)
        {
            return new Technology()
            {
                Name = name
            };
        }
    }
}
