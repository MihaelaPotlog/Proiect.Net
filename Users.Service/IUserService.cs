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
        Task<IResponseDto> Login(LoginUserDto request, CancellationToken cancellationToken);
        Task<IResponseDto> Register(CreateUserDto request, CancellationToken cancellationToken);
        Task<UserDto> GetUser(string Id, CancellationToken cancellationToken);
        Task<List<UserDto>> GetUserSuggestions(string[] neededTechnologies, CancellationToken cancellationToken);
    }
}
