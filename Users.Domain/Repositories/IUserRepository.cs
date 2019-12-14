using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Models;

namespace Users.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<User> Get(Guid userId, CancellationToken cancellationToken);
        public Task<User> Update(User user, CancellationToken cancellationToken);
        bool Delete(Guid userId);
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);
        Task<User> Add(string firstName, string lastName, string username, string email, string password, CancellationToken cancellationToken);
        Task AddUserTechnologyLinks(string[] knownTechnologies, User user, CancellationToken cancellationToken);
        Task<User> GetByUsername(string username, CancellationToken cancellationToken);
        Task<Technology> GetTechnologyByName(string technologyName, CancellationToken cancellationToken);
        Task RemoveUserTechnologyLinks(string[] removedTechnologiesNames, User user, CancellationToken cancellationToken);
    }
}
