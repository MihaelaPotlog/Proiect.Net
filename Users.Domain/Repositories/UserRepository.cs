using System;
using System.Collections.Generic;
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

        public IEnumerable<User> GetAll()
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
    }
}
