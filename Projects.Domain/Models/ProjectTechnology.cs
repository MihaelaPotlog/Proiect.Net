using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class ProjectTechnology
    {
        public Guid ProjectId { get; set; }
        public Guid TechnologieId { get; set; }
        public Project Project { get; set; }
        public Technology Technologie { get; set; }
    }
}
