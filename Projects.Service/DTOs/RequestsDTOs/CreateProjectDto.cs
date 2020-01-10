using System;

namespace Projects.Service.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Description { get; set; }
        public string[] Technologies { get; set; }
        public string State { get; set; }
    }
}
