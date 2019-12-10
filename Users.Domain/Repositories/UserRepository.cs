using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Users.Domain.Models;

namespace Users.Domain.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly UsersContext _context;
        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return new List<User>();
        }

        public User Get(Guid UserId)
        {
            return new User();
        }

        public User Update(User user)
        {
            return new User();
        }

        public bool Delete(Guid userId)
        {
            return true;
        }


        public User GetByEmail(string email)
        {
            return _context.Users.Where(user => user.Email == email).FirstOrDefault();


        }

        public User Add(string firstName, string lastName, string username, string email, string password)
        {
            var newUser = User.UserFactory(firstName, lastName, username, email, password);
            _context.Users.Add(newUser);
            return newUser;
        }

        public void AddUserTechnologyLinks(string[] knownTechnologies, User user)
        {
            foreach (string knownTechnology in knownTechnologies)
            {
                var technology = _context.Technologies.Where(t => t.Name == knownTechnology).ToList<Technology>();
                var UserTechnologyLink = new UserTechnology();
                UserTechnologyLink.User = user;
                UserTechnologyLink.Technology = technology[0];
                _context.UserTechnologies.Add(UserTechnologyLink);
            }
            _context.SaveChanges();
        }


        public void RemoveUserTechnologyLinks(string[] removedTechnologiesNames, User user)
        {
            if (removedTechnologiesNames.Length != 0)
            {
                List<UserTechnology> userTechnologyLinks = _context.UserTechnologies.ToList();

                foreach (string removedTechnologyName in removedTechnologiesNames)
                {
                    Technology removedTechnology = GetTechnologyByName(removedTechnologyName);

                    UserTechnology userTechnologyLink = userTechnologyLinks.Find(link =>
                        link.TechnologyId == removedTechnology.Id
                        && link.UserId == user.Id);

                    _context.UserTechnologies.Remove(userTechnologyLink);
                }
                _context.SaveChanges();
            }
        }

        public Technology GetTechnologyByName(string technologyName)
        {
            return _context.Technologies.First(technology => technology.Name == technologyName);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Where(e => e.Username == username).First();
        }
    }
}
