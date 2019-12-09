using System;
using System.Collections.Generic;

namespace Users.Domain.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public List<UserTechnologie> UserTechnologies { get; private set; }

        public User()
        {
            Id = Guid.NewGuid();
            UserTechnologies = new List<UserTechnologie>();
        }
        public static User UserFactory(string firstName, string lastName, string username, string email, string password)
        {
            User newStudent = new User()
            {

                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Email = email,
                Password = password

            };
            return newStudent;
        }
    }
}