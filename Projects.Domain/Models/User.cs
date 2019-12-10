using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public List<ProjectUser> ProjectUsers { get; set; }

        public User()
        {
            ProjectUsers = new List<ProjectUser>();
        }
    }
}
