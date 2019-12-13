using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Models;
using Users.Service.DTOs;

namespace Users.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(); 
        User LoginUser(LoginUserDto request);
        string RegisterUser(CreateUserDto request);
        string ModifyUser(ModifyUserDto request);
    }
}
