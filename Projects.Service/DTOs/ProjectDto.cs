using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Projects.Service.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Description { get; set; }
        public List<string> Technologies { get; set; }
        public List<Guid> CollaboratorsId { get; set; }
        public string State { get; set; }
    }
}
