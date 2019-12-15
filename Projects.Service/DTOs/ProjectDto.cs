using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Service.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Description { get; set; }
        public string[] Technologies { get; set; }
        public string State { get; set; }
    }
}
