using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Users.Domain.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; } 
        
        public List<UserTechnology> UserTechnologies { get; private set; }

        internal User()
        {
            UserTechnologies = new List<UserTechnology>();
        }
        public static User UserFactory(string email, string username,string firstName, string lastName)
        {
            User newStudent = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = username
            };
            return newStudent;
        }
    }
}