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
        Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken);
        Task<IEnumerable<Technology>> GetTechnologies(CancellationToken cancellationToken);
        Task<User> LoginUser(LoginUserDto request, CancellationToken cancellationToken);
        Task<string> RegisterUser(CreateUserDto request, CancellationToken cancellationToken);
        Task<string> ModifyUser(ModifyUserDto request, CancellationToken cancellationToken);
        Task<UserDto> GetUser(Guid Id, CancellationToken cancellationToken);
        Task<List<UserDto>> GetUserSuggestions(string[] neededTechnologies, CancellationToken cancellationToken);
    }
}
