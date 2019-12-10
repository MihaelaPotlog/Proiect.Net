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

        public Technology()
        {
            Id = Guid.NewGuid();
            ProjectTechnologies = new List<ProjectTechnology>();
        }
    }
}
