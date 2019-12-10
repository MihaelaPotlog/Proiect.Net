using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Models;

namespace Users.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(Guid userId);
        User Update(User user);
        bool Delete(Guid userId);
        User GetByEmail(string email);
        User Add(string firstName, string lastName, string username, string email, string password);
        void AddUserTechnologyLinks(string[] knownTechnologies, User user);
        User GetByUsername(string username);
        Technology GetTechnologyByName(string technologyName);
        void RemoveUserTechnologyLinks(string[] removedTechnologiesNames, User user);
    }
}
