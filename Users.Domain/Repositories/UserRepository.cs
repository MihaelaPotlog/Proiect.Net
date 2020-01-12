using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Models;

namespace Users.Domain.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UsersContext _context;
		public UserRepository(UsersContext context)
		{
			_context = context;
		}

		public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
		{
			return await _context.Users
						.Include(user => user.UserTechnologies)
							.ThenInclude(userTechnology => userTechnology.Technology)
						.ToListAsync(cancellationToken);
		}

		public async Task<List<Technology>> GetAllTechnologies(CancellationToken cancellationToken)
		{
			return await _context.Technologies.ToListAsync(cancellationToken);
		}

		public async Task<User> GetUser(Guid userId, CancellationToken cancellationToken)
		{
			User user = await _context.Users.Include(user => user.UserTechnologies)
												.ThenInclude(userTechnology => userTechnology.Technology)
											.Where(thisUser => thisUser.Id == userId)
											.FirstOrDefaultAsync(cancellationToken);

			return user;
		}

		public async Task<User> Update(User user, CancellationToken cancellationToken)
		{
			_context.Update(user);
			await _context.SaveChangesAsync(cancellationToken);
			return user;
		}


		public bool Delete(Guid userId)
		{
			return true;
		}


		public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
		{
			return await _context.Users.FirstOrDefaultAsync(user => user.Email == email, cancellationToken);


		}

		public async Task<User> Add(string firstName, string lastName, string username, string email, string password, CancellationToken cancellationToken)
		{
			var newUser = User.UserFactory(firstName, lastName, username, email, password);
			_context.Users.Add(newUser);
			await _context.SaveChangesAsync(cancellationToken);
			return newUser;
		}

		public async Task AddUserTechnologyLinks(string[] knownTechnologies, User user, CancellationToken cancellationToken)
		{
			foreach (string knownTechnology in knownTechnologies)
			{
				var technology = await _context.Technologies.Where(t => t.Name == knownTechnology).ToListAsync(cancellationToken);
				var userTechnologyLink = new UserTechnology();
				userTechnologyLink.User = user;
				userTechnologyLink.Technology = technology[0];
				_context.UserTechnologies.Add(userTechnologyLink);
			}
			await _context.SaveChangesAsync(cancellationToken);
		}


		public async Task RemoveUserTechnologyLinks(string[] removedTechnologiesNames, User user, CancellationToken cancellationToken)
		{
			if (removedTechnologiesNames.Length != 0)
			{
				List<UserTechnology> userTechnologyLinks = _context.UserTechnologies.ToList();

				foreach (string removedTechnologyName in removedTechnologiesNames)
				{
					Technology removedTechnology = await GetTechnologyByName(removedTechnologyName, cancellationToken);

					UserTechnology userTechnologyLink = userTechnologyLinks.Find(link =>
						link.TechnologyId == removedTechnology.Id
						&& link.UserId == user.Id);

					_context.UserTechnologies.Remove(userTechnologyLink);
				}
				_context.SaveChanges();
			}
		}

		public async Task<Technology> GetTechnologyByName(string technologyName, CancellationToken cancellationToken)
		{
			return await _context.Technologies.FirstAsync(technology => technology.Name == technologyName, cancellationToken);
		}

		public async Task<User> GetByUsername(string username, CancellationToken cancellationToken)
		{
			return await _context.Users.FirstOrDefaultAsync(e => e.Username == username, cancellationToken);
		}

		public async Task<List<User>> GetUserByProjectTech(string[] neededTechNames, CancellationToken cancellationToken)
		{
			List<User> suggestedUsers = new List<User>();
			List<User> allUsers = await _context.Users.Include(user => user.UserTechnologies)
									.ThenInclude(userTechnology => userTechnology.Technology)
									.ToListAsync(cancellationToken);
			foreach (var user in allUsers)
			{
				if (neededTechNames.Intersect(user.UserTechnologies.Select(element => element.Technology.Name)).Count() != 0)
				{
					suggestedUsers.Add(user);
				}
			}
			return suggestedUsers;

		}
	}
}
