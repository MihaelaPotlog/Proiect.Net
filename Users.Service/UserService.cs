using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Users.Domain.Models;
using Users.Domain.Repositories;
using Users.Service.DTOs;
using Users.Service.Validators;

namespace Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _userRepository.GetAllUsers(cancellationToken);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task<UserDto>GetUser(Guid Id,CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUser(Id, cancellationToken);
            return _mapper.Map<UserDto>(user);

        }
        public async Task<IEnumerable<Technology>> GetTechnologies(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllTechnologies(cancellationToken);
        }

        public async Task<User> LoginUser(LoginUserDto request, CancellationToken cancellationToken)
        {
            var emailToCheck = request.Email;
            var passwordToCheck = request.Password;
            var addr = new EmailAddressAttribute();

            if (addr.IsValid(emailToCheck))
            {
                var foundUser = await _userRepository.GetByEmail(emailToCheck, cancellationToken);
                if (passwordToCheck == foundUser.Password)
                    return foundUser;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> RegisterUser(CreateUserDto request, CancellationToken cancellationToken)
        {
          
            CreateUserDtoValidator dtoValidator = new CreateUserDtoValidator(_userRepository);
            var result = await dtoValidator.ValidateAsync(request, cancellationToken);

            if (result.IsValid == true)
            {
                var currentUser = await _userRepository.Add(request.FirstName, request.LastName, request.Username,
                    request.Email, request.Password, cancellationToken);
                
                await _userRepository.AddUserTechnologyLinks(request.KnownTechnologies, currentUser, cancellationToken);

                return "success";
            }

            return result.ToString();
        }

        public async Task<string> ModifyUser(ModifyUserDto request, CancellationToken cancellationToken)
        {
            User modifiedUser = await _userRepository.GetUser(request.Id, cancellationToken);
            if (modifiedUser == null)
                return "invalid id";
            ModifyUserDtoValidator modifyUserValidator = new ModifyUserDtoValidator(_userRepository);
            var  validationResult = await modifyUserValidator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                return validationResult.ToString();

            modifiedUser.FirstName = request.FirstName;
            modifiedUser.LastName = request.LastName;
            modifiedUser.Username = request.Username;
            await _userRepository.Update(modifiedUser, cancellationToken);

            await _userRepository.AddUserTechnologyLinks(request.AddedTechnologiesNames, modifiedUser, cancellationToken);
            await _userRepository.RemoveUserTechnologyLinks(request.RemovedTechnologiesNames, modifiedUser, cancellationToken);

            return "success";
        }
    }
}