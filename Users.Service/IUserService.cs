using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Models;

namespace Users.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
