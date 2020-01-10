using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Models;
using Users.Service.DTOs;

namespace Users.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
        Task<IEnumerable<Technology>> GetTechnologies(CancellationToken cancellationToken);
        Task<User> LoginUser(LoginUserDto request, CancellationToken cancellationToken);
        Task<string> RegisterUser(CreateUserDto request, CancellationToken cancellationToken);
        Task<string> ModifyUser(ModifyUserDto request, CancellationToken cancellationToken);
        Task<User> GetUser(Guid Id, CancellationToken cancellationToken);
    }
}
