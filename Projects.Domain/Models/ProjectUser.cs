using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class ProjectUser
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}
