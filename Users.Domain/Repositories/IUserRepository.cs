using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Models;

namespace Users.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(Guid userId);
        User Update(User user);
        bool Delete(Guid userId);
    }
}
