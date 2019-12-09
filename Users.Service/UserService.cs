using System;
using System.Collections.Generic;
using Users.Domain.Models;
using Users.Domain.Repositories;

namespace Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
