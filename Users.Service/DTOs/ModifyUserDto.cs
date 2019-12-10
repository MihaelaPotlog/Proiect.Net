using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Service.DTOs
{
    public class ModifyUserDto
    {
        public Guid Id { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string NewUsername { get; set; }
        public string[] AddedTechnologiesNames { get; set; }
        public string[] RemovedTechnologiesNames { get; set; }
    }
}
