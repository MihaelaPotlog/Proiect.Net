using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Service.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; internal set; }
        public string Username { get; set; }
        public string[] KnownTechnologies { get; set; }
    }
}
